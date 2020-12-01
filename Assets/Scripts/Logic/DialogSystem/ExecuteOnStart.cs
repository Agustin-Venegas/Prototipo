using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExecuteOnStart : MonoBehaviour
{
    public UnityEvent toDo;
	
    void Start()
    {
        toDo.Invoke();
		enabled = false;	
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
