using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpells : MonoBehaviour
{

    public float Cooldown_Modifier; //negativo o positivo, positivo es menos cooldown

    public InventorySlot[] spells;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (spells[0].item != null) 
            {
                
            }
        }
    }
}
