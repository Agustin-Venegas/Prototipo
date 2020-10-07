using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
 * Este Behaviour se pone en los objetos que son balas, cohetes, laseres,etc
 * Al espawnear, acelera el objeto, y si toca algo a lo que se le haga daño, 
 * le hace daño y despawnea
 * 
 * Tiene daño y multiplicador de velocidad
 * Puede invocar otras cosas y funciones antes de despawnear
 * 
 * Se recomienda que el rigidbody del objeto no tenga roce lineal
 */

public class ProjectileBehaviour : MonoBehaviour
{
    [Header("Vars")]
    public int Damage = 10;
    public float SpeedMultiplier = 20f;
    public bool DieOnImpact = false;
    public float Time_Alive = 1f; //tiempo vivo

    float timer = 0;

    [Header("Al Impactar")]
    public UnityEvent OnHit;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = (transform.up * SpeedMultiplier);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= Time_Alive)
        {
            OnHit.Invoke();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        IHurtable hurt = coll.gameObject.GetComponent<IHurtable>();

        if (hurt != null && coll.isTrigger == false)
        {
            hurt.Hurt(Damage);
            OnHit.Invoke();

            if (DieOnImpact) Destroy(gameObject);
        }
        else
        {
            if (coll.isTrigger == false)
            {
                if (DieOnImpact) Destroy(gameObject);
            }
        }
    }
}
