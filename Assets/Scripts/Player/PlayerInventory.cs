using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* esto va a manejar cuando el jugador
abra el inventario y empieze a apretar con el mouse cosas
*/
public class PlayerInventory : MonoBehaviour
{
    public int MAX_INVENTORY = 12;

    public static PlayerInventory Instance;

    public List<InventoryItem> list;

    public GameObject Player;
    public GameObject Panel;

    public InventorySlot Selected {get; set;}

    void Start()
    {
        Instance = this;
        UpdatePaneles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdatePaneles() 
    {
        int i = 0;

        foreach (Transform c in Panel.transform) //esto itera todos los botones hijos del objeto
        {
            InventorySlot slot = c.GetComponent<InventorySlot>(); //obtenemos el slot

            if (i < list.Count) //si hay un objeto aqui
            {
                //esta condicion es por si el slot es especial y recibe de un tipo
                if (slot.recibe == null || slot.recibe == list[i].tipo)
                {
                    slot.item = list[i]; //asignamos el objeto al slot
                    i++; //pusimos un objeto, pasamos al siguiente
                }
            } else
            {
                slot.item = null; //si no hay objeto, no le ponemos
            }

            slot.Actualizar(); //cada slot cambia su grafico
        }
    }

    public bool Add(InventoryItem i) 
    {

        bool succ = false; //guardamos si se logra meter

        //si cabe en la lista, meterlo
        if (list.Count < MAX_INVENTORY) 
        {
            list.Add(i);
            succ = true;
        }

        UpdatePaneles(); //actualizar

        return succ;
    }

    public void Remover(InventoryItem i) 
    {
        list.Remove(i); //saca el objeto de la lista y actualiza
        UpdatePaneles();
    }
}
