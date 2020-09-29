using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDump : MonoBehaviour
{
    public GameObject container;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EliminarObjeto(InventoryItem item)
    {
        if (item != null) 
        {
            GameObject proj = Instantiate(container, PlayerObject.Instance.gameObject.transform);

            proj.transform.position += PlayerObject.Instance.gameObject.transform.up*2;

            proj.gameObject.GetComponent<ItemRecogible>().AsignarObjeto(item);
        }
    }

    public void Comprobar() 
    {
        if (PlayerInventory.Instance.Selected != null) 
        {
            InventoryItem i = PlayerInventory.Instance.Selected.item; //guardamos una referencia al objeto
            
            if (PlayerInventory.Instance.Selected.recibe == null) //si NO es un slot especial
            {
                PlayerInventory.Instance.Remover(i); //pal lobby
            }

            if (i != null) EliminarObjeto(i); //lo tiramos
            PlayerInventory.Instance.Selected = null;
        } 
    }
}
