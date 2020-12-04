using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum IAState //estados ia
{
    Idle, //no esta persiguiendo
    Sospecha, //vio un cadaver o algo
    Perseguir, //no ve al jugador pero se mueve a la ultima pos
    Ataque, //disparando
}

public class EnemyObject : MonoBehaviour, IHurtable
{
    public Animator animator;
    [Header("Vars")]
    public int maxHp = 20; //Hit Points Máximos.
    int hp; //Hit Points actuales
    public float AttackCooldown = 0f; //delay extra para el ataque
    float attack_timer = 0;
	public float speed = 3.5f;

    [Header("Partes")]
    public AttackContainer attack; //el ataque que usa
    public Rigidbody2D rb;
    public Condicion cond; //si matarlo es condicion de pasar
    public GameObject Drop; //arma q dropea

    [Header("Var IA")]
    Transform Target; //cosa que llama la atencion
    public IAState state; //como esta
    float timer; //temporizador de no realziar acciones, stun, etc
    NavMeshAgent nav; //la cosa de IA best comentario ever


    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp; //El hp inicial será igual a la cantidad máxima de hp.

        rb = gameObject.GetComponent<Rigidbody2D>();

        nav = gameObject.GetComponent<NavMeshAgent>();

        //esto es porsiacaso el motor trata de rotar el objeto
        nav.updateRotation = false;
        nav.updateUpAxis = false;
		nav.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {

        if (timer > 0) //si está stuneado o algo
        {
            timer -= Time.deltaTime; //des estunear

            nav.speed = 0f; //detener
        }
        else //si no esta estuneado
        {

            nav.speed = speed;

            /*crei q tendria q usar esto de switch
             * Hice un juego parecido hace 2 semestres
             * y use switch para la IA
             * */

            switch (state)
            {
                case IAState.Idle:

                    break;

                case IAState.Sospecha:
                    RotarHacia(nav.steeringTarget);
                    break;

                case IAState.Perseguir:
                    RotarHacia(nav.steeringTarget);
                    break;

                case IAState.Ataque:
                    Ataque();
                    animator.SetBool("Shoot", true);
                    break;
            }
        }
    }

    public bool IsAlive() { return hp > 0; }


    //esto hace que el enemigo sospeche y vaya a revisar un objeto
    public void PasarSospechar(Collider2D other)
    {
        timer = 1;

        state = IAState.Sospecha;

        nav.destination = other.transform.position;
    }

    public void PasarSospechar(Vector3 v)
    {
        timer = 0.1f;

        state = IAState.Sospecha;

        nav.destination = v;
    }

    public bool Hurt(int d)
    {
        if (IsAlive()) 
        { 
            hp -= d;

            timer = 0.3f;

            if (state != IAState.Ataque) //se alerta
            {
                PasarSospechar(PlayerObject.Instance.gameObject.transform.position);
            }

            if (!IsAlive())
            {
                Die();
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    void OnTriggerExit2D(Collider2D coll) //usamos esto pa cuando el jugador desaparece
    {
        //si estaba atacando y el jugador desaparece
        if (coll.gameObject.GetComponent<PlayerObject>() != null && state == IAState.Ataque)
        {
            PasarPersecucion();
            nav.destination = coll.transform.position;
        }
    }

    void OnTriggerStay2D(Collider2D coll) //usamos esto pa ver si el jugador esta siendo visto
    {
        //si el jugador entra al espacio, siempre se alerta
        if (coll.gameObject.GetComponent<PlayerObject>() != null)
        {
            //direcion hacia el jugador
            Vector3 direction = coll.gameObject.transform.position - gameObject.transform.position;

            float len = direction.magnitude;

            direction.Normalize(); //lo obtenemos como direccion

            //tiramos un rayo en la direccion pa ver las paredes
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, len, LayerMask.GetMask("Default"), 0, Mathf.Infinity);

            if (hit == false)
            {
                Target = coll.gameObject.transform; //objetivo

                if (state != IAState.Ataque)
                {
                    PasarAtaque();
                }
            }
            else if (hit.collider != null)
            {
                if (state == IAState.Ataque)
                {
                    PasarPersecucion();
                    nav.destination = coll.transform.position;
                }
            }
        }

        //si ve algo sospechoso
        if (coll.gameObject.GetComponent<Sospecha>() != null)
        {

            //tiramos un rayo pa ver las paredes
            Vector3 direction = coll.gameObject.transform.position - gameObject.transform.position;
            float len = direction.magnitude;
            direction.Normalize(); //lo obtenemos como direccion

            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, len, LayerMask.GetMask("Default"), 0, Mathf.Infinity);
            if (hit == false) //no hay paredes
            {
                if (state != IAState.Perseguir && state != IAState.Ataque) //pasamos a sospechar
                {
                    PasarSospechar(coll);
                }
            }
        }
    }

    public void Die()
    {
        enabled = false; //desactiva el enemigo
        animator.SetBool("Dead", true);
        nav.enabled = false; //desactiva el perseguidor
        rb.simulated = false;

        GetComponent<SpriteRenderer>().sortingOrder = -1;


        //gameObject.SetActive(false);
        Drop.GetComponent<ItemRecogible>().enabled = true;
        Drop.GetComponent<ItemRecogible>().Activar(true);
        Drop.transform.parent = null;

        if (cond != null) cond.completada = true; //completa un objetivo
        if (MisionManager.Instance != null) MisionManager.Instance.CheckComplete(); //actualizamos la mision del nivel
    }

    void PasarAtaque()
    {
        state = IAState.Ataque; //pasamos a atacar
        rb.isKinematic = false; //activar colisiones
    }

    void PasarPersecucion()
    {
        Target = null;
        state = IAState.Perseguir;
        rb.isKinematic = true;
    }

    public void Ataque() //cosa para atacar
    {

        Vector3 dif = Target.position - transform.position;
        //float angle = Vector2.SignedAngle(Target.transform.position, transform.position);

        float angle = (Mathf.Atan2(dif.y, dif.x) - Mathf.PI / 2) * Mathf.Rad2Deg;

        float dr = 180 * Time.deltaTime;
        float new_angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, angle, dr);

        transform.eulerAngles = new Vector3(0, 0, new_angle);


        if (attack.IsMelee)
        {
            //aqui debe tirarse hacia el jugador
			rb.velocity = new Vector2(Mathf.Cos(new_angle), Mathf.Sin(new_angle)) * speed;
        }

        if (attack.CanShoot())
        {
            attack_timer += Time.deltaTime;

            if (attack_timer >= AttackCooldown)
            {
                attack_timer = 0;
                attack.Shoot(transform);
            }
        }
    }

    public void RotarHacia(Vector3 v)
    {
        Vector3 dif = v - transform.position;

        float angle = (Mathf.Atan2(dif.y, dif.x) - Mathf.PI / 2) * Mathf.Rad2Deg;

        float dr = 180 * Time.deltaTime;
        float new_angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, angle, dr);

        transform.eulerAngles = new Vector3(0, 0, new_angle);
    }
}
