using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThotSwordBehaviour : MonoBehaviour
{
    [Header("Manguito")]
    public Transform Manguito; //punto a rotar

    [Header("Variables")]
    public float Angle = 115.0f; //angulo en deg
    public float Timer = 0.3f; //tiempo segundo
    public int Damage = 5;
    public int ExtraDamage = 0;
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
		
		SpecialTrigger(coll);
		
        IHurtable hurt = coll.gameObject.GetComponent<IHurtable>() as IHurtable;

        if (hurt != null && coll.isTrigger == false)
        {
            hurt.Hurt(Damage + Random.Range(0, ExtraDamage + 1));

            if (hurt is EnemyObject)
            {
                OnHitEnemy.Invoke();
            }

            if (DespawnsOnHit) Destroy(this.gameObject);
        }
    }
	
	public void SpecialTrigger(Collider2D coll) 
	{
		ProjectileBehaviour p = coll.gameObject.GetComponent<ProjectileBehaviour>();
		
		if (p != null) 
		{
			if (p.Damage < 20) 
			{
				coll.GetComponent<Rigidbody2D>().velocity = (PlayerObject.Instance.transform.up * p.SpeedMultiplier);
			}
		}
	}
}
