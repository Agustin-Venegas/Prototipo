using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Consumible : InventoryItem
{
    public UnityEvent AlConsumir;

    void Start()
    {
        tipo = "Consumible";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Usar()
    {
        base.Usar();

        AlConsumir.Invoke();

        PlayerInventory.Instance.Remover(this);
    }
}
