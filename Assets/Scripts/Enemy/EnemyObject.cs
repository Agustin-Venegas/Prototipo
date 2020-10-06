using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour, IHurtable
{
    public int maxHp = 20; //Hit Points Máximos.
    int hp;    //Hit Points

    public Transform Target;

    bool alarmed = false;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp; //El hp inicial será igual a la cantidad máxima de hp.
    }

    // Update is called once per frame
    void Update()
    {

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

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<PlayerObject>() != null)
        {

        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(Target.position.y - transform.position.y, Target.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 15 * Time.deltaTime);
    }
}
