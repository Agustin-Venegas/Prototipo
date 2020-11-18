using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/*
 * Este script debe ponerse en aquellos objetos
 * que sean ataques melee cuerpo a cuerpo
 * Lo que hace es rotar  el gameobject, y si topa a algo
 * a lo que se le haga damage, le hara damage y se despawneara,
 * dependiendo de un booleano
 * Hay tiempo que dura y angulo que gira,
 * no recuerdo bien si el angulo era en rad o deg en unity :c
 * pero parece que estos wetas lo dejaron con degs
 * */

public class MeleeBehaviour : MonoBehaviour
{
    [Header("Manguito")]
    public Transform Manguito; //punto a rotar

    [Header("Variables")]
    public float Angle = 115.0f; //angulo en deg
    public float Timer = 0.3f; //tiempo segundo
    public int Damage = 5;
    public bool DespawnsOnHit = true;

    [Header("Al Golpear")]
    public UnityEvent OnHitEnemy;

    private float dAngle;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        dAngle = Angle / Timer;
        timer = Timer;
    }

    // Update is called once per frame
    void Update()
    {
        Manguito.Rotate(0f, 0f, dAngle * Time.deltaTime);
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        IHurtable hurt = coll.gameObject.GetComponent<IHurtable>() as IHurtable;

        if (hurt != null && coll.isTrigger == false)
        {
            hurt.Hurt(Damage);

            if (hurt is EnemyObject)
            {
                OnHitEnemy.Invoke();
            }

            if (DespawnsOnHit) Destroy(this.gameObject);
        }
    }
}
