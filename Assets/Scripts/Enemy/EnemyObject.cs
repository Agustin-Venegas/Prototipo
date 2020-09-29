using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    public float hp;    //Hit Points
    public float maxHp; //Hit Points Máximos.
    // Start is called before the first frame update
    void Start()
    {
        maxHp = 20; //Hp máximo igual a 20;
        hp = maxHp; //El hp inicial será igual a la cantidad máxima de hp.
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)    //Si el hp es menor o igual a 0.
        {
            Destroy(gameObject);    //Se destruye a si mismo.
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hp -= 5;
            Destroy(collision.gameObject);
        }
    }
}
