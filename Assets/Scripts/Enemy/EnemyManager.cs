using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public EnemyObject[] list;
    public static EnemyManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Alertar(Vector3 v, float r)
    {
        foreach (EnemyObject e in list)
        {
            if (e.IsAlive()) //si esta vivo y cerca
            {
                if (e.state != IAState.Ataque && Vector3.Distance(e.transform.position, v) < r)
                {
                    e.PasarSospechar(v);
                }
            }
        }
    }
}
