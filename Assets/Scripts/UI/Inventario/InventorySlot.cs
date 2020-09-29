using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public InventoryItem item;
    public string recibe = null;

    void Start() 
    {

    }

    public void Use() 
    {
        if (item)
        {
            item.Usar();
        }
    }

    public void Actualizar() 
    {
        Text t = transform.Find("Text").GetComponent<Text>(); 
        
        if (item) 
        {
            t.text = item.name;
        } else 
        {
            t.text = "";
        }
    }

    public void Comprobar() //esto se va a ejecutar cuando se haga click
    {
        InventorySlot i = PlayerInventory.Instance.Selected;

        //si no hay algo seleccionado
        if (i == null) 
        {
            //seleccionamos este
            PlayerInventory.Instance.Selected = this;
        } else 
        {
            //si hay algo seleccionad
            if (this == i) //y es este mismo
            {
                if (item.tipo == "Consumible") item.Usar();

                if (recibe != null) //si esto es un slot de armadura/magia/arma
                {
                    //devolvemos el objeto a la lista/inventario
                    if (PlayerInventory.Instance.Add(item)) item = null;
                }

                PlayerInventory.Instance.Selected = null;
            } else 
            {
                //cambiar items, solo se cambia si es un slot de arma/hechizo/etc
                if (recibe != null && recibe == i.item.tipo)
                {
                    CambiarConElSeleccionado();
                }

                PlayerInventory.Instance.Selected = null; //ya no hay seleccionado
            }
        }
    }

    public void CambiarConElSeleccionado() 
    {
        //Cambia este item con el del seleccionado previamente con un auxiliar

        InventoryItem i = PlayerInventory.Instance.Selected.item;

        PlayerInventory.Instance.Selected.item = item;
        item = i;

        PlayerInventory.Instance.Remover(item);
    }
}
