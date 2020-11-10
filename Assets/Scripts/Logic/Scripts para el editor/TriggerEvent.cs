﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//esto activa algo al chocar con el personaje

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent OnTrigger;
    public bool DestroyOnTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<PlayerObject>() != null)
        {
            OnTrigger.Invoke();

            if (DestroyOnTrigger) Destroy(gameObject);
        }
    }
}
