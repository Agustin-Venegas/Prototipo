using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//esto se encarga de contener el ataque del jugador
//y de activarlo con una tecla

public class PlayerAttack : MonoBehaviour
{
    [Header("Partes")]
    public Transform firePoint;
    public AttackContainer attack;
    public AttackContainer DefaultAttack;
    public HabilidadEspecial special;
    public HUD hud;

    [Header("Vars")]
    public bool CanPickupWeapons = true;
    public bool ActivateSpecialOnShoot = false;

    public static PlayerAttack Instance;

    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if (attack != null)
            {
                if (attack.CanShoot()) attack.Shoot(firePoint);
                if (ActivateSpecialOnShoot) special.Activate();
            }
            else
            {
                if (DefaultAttack.CanShoot()) DefaultAttack.Shoot();
                if (ActivateSpecialOnShoot) special.Activate();
            }

            UpdateHUD();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (CanPickupWeapons && attack != null)
            {
                LanzarArma();
            }
            else
            {
                if (special != null) special.Activate();
            }
        }
    }

    public void AsignAttack(AttackContainer other)
    {
        if (CanPickupWeapons) 
        { 
            attack = other;
            hud.UpdateWeapon(attack.getAmmo(), attack.Max_Ammo, attack.Descripcion, attack.img, attack.UsesAmmo);
        }
    }

    public void UpdateHUD()
    {
        if (attack != null)
        {
            if (attack.UsesAmmo) hud.UpdateWeapon(attack.getAmmo(), attack.Max_Ammo);
        }
    }

    public void LanzarArma()
    {

    }
}
