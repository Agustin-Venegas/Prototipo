using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//objeto que al colisionar con el jugador, da un objeto

public class ItemRecogible : MonoBehaviour
{
    public InventoryItem itemDado;

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
            PlayerInventory.Instance.Add(itemDado);

            Destroy(gameObject);
        }
    }

    public void AsignarObjeto(InventoryItem i) //funcion innecesaria pero me sirve pa recordar todo
    {
        itemDado = i; //no se si esto funcione
        //es bastante probable que con esto, crear muchos objetos genere hoyos en la memoria
    }
}
