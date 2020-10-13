using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MisionManager : MonoBehaviour
{
    public List<Condicion> condiciones;
    public bool ActivateOnComplete = false;

    public UnityEvent OnComplete;

    public bool accomplished = false;

    public static MisionManager Instance;

    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckComplete()
    {
        foreach (Condicion c in condiciones)
        {
            if (c.completada == false) return false;
        }

        if (ActivateOnComplete)
        {
            OnComplete.Invoke();
        }

        accomplished = true;

        return true;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<PlayerObject>() != null)
        {
            if (accomplished)
            {
                if (!ActivateOnComplete && CheckComplete())
                {
                    OnComplete.Invoke();
                }
            }
        }
    }
}
