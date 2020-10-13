using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour, IHurtable
{
    [Header("Vars")]
    public int maxHp = 20; //Hit Points Máximos.
    int hp;    //Hit Points

    [Header("Partes")]
    public AttackContainer attack;
    public Condicion cond;

    GameObject Target;
    bool alarmed = false;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp; //El hp inicial será igual a la cantidad máxima de hp.
    }

    // Update is called once per frame
    void Update()
    {
        if (alarmed && Target != null)
        {
            RotateTowardsTarget();

            if (attack.CanShoot()) attack.Shoot();
        }
    }

    public bool IsAlive() { return hp > 0; }

    public bool Hurt(int d)
    {
        hp -= d;

        if (!IsAlive())
        {
            Die();
            return true;
        }

        return false;
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        //si el jugador entra al espacio
        if (coll.gameObject.GetComponent<PlayerObject>() != null && Target == null)
        {
            //direcion hacia el jugador
            Vector3 direction = coll.gameObject.transform.position - gameObject.transform.position;

            float len = direction.magnitude;

            direction.Normalize(); //lo obtenemos como direccion

            //tiramos un rayo pa ver las paredes
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, len, LayerMask.GetMask("Default"), 0, Mathf.Infinity);
            if (hit == false)
            {
                alarmed = true;
                Target = coll.gameObject;
            }
        }

        if (coll.gameObject.GetComponent<PlayerObject>() != null)
        {
            Debug.DrawRay(transform.position,  coll.transform.position - transform.position, Color.red);
        }
    }

    public void Die()
    {
        enabled = false;
        gameObject.SetActive(false);
        cond.completada = true;
        MisionManager.Instance.CheckComplete();
    }

    private void RotateTowardsTarget()
    {
        /*
         * float angle = Mathf.Atan2(Target.position.y - transform.position.y, Target.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 15 * Time.deltaTime);
        */

        Vector2 dir = Target.transform.position - transform.position;
        transform.up = dir; //seguir al objetivo, asi de simple
    }
}
