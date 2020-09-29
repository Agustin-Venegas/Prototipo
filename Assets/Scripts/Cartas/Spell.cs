using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Esto describe un spell
 * Un spell se almacena en una lista en una parte del jugador
 * El jugador presiona un botón y se activa
 * No existen los hechizos pasivos por decirlo
 * */

public abstract class Spell : InventoryItem
{

    public int Mana_Cost;
    public float Cooldown;
    float timer = 0;

    void Start()
    {
        tipo = "Hechizo";
    }

    void Update()
    {
        
    }

    public void Invoke()
    {
        if (timer == 0)
        {
            if (PlayerObject.Instance.GetEnergy() >= Mana_Cost)
            {
                timer = Cooldown - PlayerObject.Instance.spell.Cooldown_Modifier;
                PlayerObject.Instance.UseEnergy(Mana_Cost);
            }
        }
    }

    public abstract void OnInvoke(); //lo que se hace al activar el hechizo
}
