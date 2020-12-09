using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEditor;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    /*Controles*/

    //Keys utilizadas en el movimiento sobre el eje Y del objeto.
    KeyCode up; //Arriba.
    KeyCode down;   //Abajo.

    //Keys utiliadas en el movimiento sobre el eje X del objeto.
    KeyCode left;   //Izquierda.
    KeyCode right;  //Derecha.

    //Key utilizada en el movimiento de impulso.
    KeyCode dash;

    /***********/
    Rigidbody2D rg2d;   //Cuerpo Rígido utilizado para acceder a la velocidad.

    private float movementX = 0;    //Movimiento en el eje X: -1 si se mueve a las izquierda, 1 si se mueve a la derecha, 0 si no se mueve. 
    private float movementY = 0;    //Movimiento en el eje Y: -1 si se mueve a las izquierda, 1 si se mueve a la derecha, 0 si no se mueve.

    private float limitedSpeedX;    //Limitará la velocidad en el eje X.
    private float limitedSpeedY;    //Limitará la velocidad en el eje Y.
    private float fixedSpeedX;  //Disminuirá gradualmente la velocidad en el eje X al dejar de pulsar los controles.
    private float fixedSpeedY;  //Disminuirá gradualmente la velocidad en el eje Y al dejar de pulsar los controles.

    private bool dashState = false;  //Estado de impulso, inicializado en false.
    private bool impulsed = false;   //Si el Jugador recibió un impulso, su valor pasa a true;

    public float speed = 50f; //Aceleración que tendrá el objeto.
    public float maxSpeed = 10;  //Velocidad máxima que el objeto podrá alcanzar.

    public float dashForce; //Fuerza de impulso.

	
	float timer = 0;

    /**********************/
    public Camera cam = null;
    Vector2 movementVec;
    Vector2 mousePos;

    public Animator animator;

    public bool isWalking;

	public GameObject HUD_item;

    public static PlayerMovements Instance;
    // Start is called before the first frame update
    void Start()
    {
        /*Inicialización de Controles*/
        up = KeyCode.W;   //Letra W.
        down = KeyCode.S;   //Letra S.
        left = KeyCode.A;   //Letra A.
        right = KeyCode.D; //Letra D.

        dash = KeyCode.Space;   //Espacio.
        /*****************************/

        rg2d = GetComponent<Rigidbody2D>();     //Rigidbody2D del portador del script.

        dashForce = speed * 0.8f;  //La fuerza será proporcional a la aceleración, multiplicada por un numero.

        Instance = this;

        if (cam == null)
        {
            cam = Camera.main;
        }

        isWalking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!impulsed)  //Si impulsed está desactivado.
        {
            
            if (Input.GetKey(right))    //Si pulsa Derecha.
            {
                rg2d.velocity += Vector2.right * speed * Time.deltaTime;    //Aumenta la velocidad hacia la derecha.
                movementX = 1;
            }
            if (Input.GetKey(left))     //Si pulsa Izquierda.
            {
                rg2d.velocity += Vector2.left * speed * Time.deltaTime;     //Aumenta la velocidad hacia la izquierda.
                movementX = -1;
            }

            if (Input.GetKey(up))   //Si pulsa Arriba.
            {
                rg2d.velocity += Vector2.up * speed * Time.deltaTime;       //Aumenta la velocidad hacia arriba.
                movementY = 1;
            }
            else if (Input.GetKey(down))    //Si pulsa Abajo.
            {
                rg2d.velocity += Vector2.down * speed * Time.deltaTime;     //Aumenta la velocidad hacia abajo.
                movementY = -1;
            }

            if (movementX != 0 || movementY != 0)
            {
                isWalking = true;
            }
            else
            {
                isWalking = false;
            }
			
			if (timer > 0) 
			{
				timer -= Time.deltaTime;
			} else 
			{
				if (!dashState) //Si dashState está desactivado.
				{
					if (Input.GetKeyDown(dash)) //Si pulsa Dash
					{
						dashState = true;   //dashState se ativa.
						timer = 2f;
					}
				}
			}
            
        }
        
        /***************************/
        movementVec.x = Input.GetAxisRaw("Horizontal");
        movementVec.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition); //posicion del mouse respecto a la camara 

		if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (HUD_item != null) HUD_item.SetActive(true);
        }
		
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            if (HUD_item != null) HUD_item.SetActive(false);
        }
    }
	
	void OnDisable() 
	{
		if (HUD_item != null) HUD_item.SetActive(false);
	}

    //Utilizar para manipular físicas y para cálculos físicos.
    private void FixedUpdate()
    {
        if (!impulsed) //Si dashState no está activado.
        {
            limitedSpeedX = Mathf.Clamp(rg2d.velocity.x, -maxSpeed, maxSpeed);  //Calcula la velocidad límite en el eje X.
            limitedSpeedY = Mathf.Clamp(rg2d.velocity.y, -maxSpeed, maxSpeed);  //Calcula la velocidad límite en el eje Y.

            rg2d.velocity = new Vector2(limitedSpeedX, limitedSpeedY);  //Asigna la velocidad límite en ambos ejes X e Y.
        }
		
        if (impulsed)   //Si impulsed está activado la disminución de velocidad es menor.
        {
            fixedSpeedX = rg2d.velocity.x * 0.8f;   //Calcula la disminución de velocidad en el eje X.
            fixedSpeedY = rg2d.velocity.y * 0.8f;   //Calcula la disminución de velocidad en el eje Y.
        }
        else
        {
            fixedSpeedX = rg2d.velocity.x * 0.4f;   //Calcula la disminución de velocidad en el eje X.
            fixedSpeedY = rg2d.velocity.y * 0.4f;   //Calcula la disminución de velocidad en el eje Y.
        }
            
        if (!Input.GetKey(left) && !Input.GetKey(right) || impulsed)    //Si Izquierda no está presionado y Derecha no está presionado.
        {
            movementX = 0;
            rg2d.velocity = new Vector2(fixedSpeedX, rg2d.velocity.y);  //Asigna la velocidad disminuida en el eje X si se cumple la condición previa.
        }
        if (!Input.GetKey(up) && !Input.GetKey(down) || impulsed)   //Si Arriba no está presionado y Abajo no está presionado.
        {
            movementY = 0;
            rg2d.velocity = new Vector2(rg2d.velocity.x, fixedSpeedY);  //Asigna la velocidad disminuida en el eje Y si se cumple la condición previa.
        }

        if (dashState && !impulsed) //Si dashState está activado e impulsed desactivado.
        {
            rg2d.AddForce(new Vector2(movementX, movementY) * dashForce, ForceMode2D.Impulse);  //Se añade una fuerza que funciona como un impulso.
            impulsed = true;    //impulsed se activa.
        }

        if (dashState && rg2d.velocity.x < maxSpeed && rg2d.velocity.x > -maxSpeed && rg2d.velocity.y < maxSpeed && rg2d.velocity.y > -maxSpeed) //Si la velocidad en en ambos ejes está entre la velocidad límite permitida.
        {
            dashState = false;  //dashState se desactiva.
            impulsed = false;   //impulsed se desactiva.
        }

        Vector2 lookDir = mousePos - rg2d.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f; //arctangente de (y,x)
        rg2d.rotation = angle;
    }
}
