using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alertar : MonoBehaviour //alerta enemigos en un area
{

    public float radius;
    public Transform point;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Alert(Vector3 v, float r)
    {
        if (EnemyManager.Instance != null) EnemyManager.Instance.Alertar(v, r);
    }
    public void Alert(Vector3 v)
    {
        if (EnemyManager.Instance != null) EnemyManager.Instance.Alertar(v, radius);
    }
    public void Alert()
    {
        if (EnemyManager.Instance != null) EnemyManager.Instance.Alertar(point.position, radius);
    }
}
