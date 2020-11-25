using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//objeto que al colisionar con el jugador, da un objeto

public class ItemRecogible : MonoBehaviour
{
    public AttackContainer itemDado;
    bool touched = false;

    [Header("Partes")]
    public SpriteRenderer sprit;
    public Collider2D col;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (touched)
            if (Input.GetButtonDown("Fire2"))
            {
                if (PlayerAttack.Instance.CanPickupWeapons) 
                {  
                    PlayerAttack.Instance.AsignAttack(itemDado);

                    //Destroy(gameObject);
                    Activar(false);
                }
            }
    }

    void OnTriggerEnter2D(Collider2D coll) 
    {
        if (coll.gameObject.GetComponent<PlayerObject>() != null) 
        {
            touched = true;
        }
    }

    public void Activar(bool r)
    {
        enabled = r;
        sprit.enabled = r;
        col.enabled = r;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<PlayerObject>() != null)
        {
            touched = false;
        }
    }

    public void AsignarObjeto(InventoryItem i)
    {

    }
}
