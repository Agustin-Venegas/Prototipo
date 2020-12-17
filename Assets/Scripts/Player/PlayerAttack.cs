using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//esto se encarga de contener el ataque del jugador
//y de activarlo con una tecla

public class PlayerAttack : MonoBehaviour
{
    public bool isShooting = false;
    public bool WithGun = false;
    public bool isHitting = false;

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

    public Animator animator;

    public float timerGolpe = 0.0f;
    public float timerShoot = 0.0f;
    public float Cooldown = 0.5f;

    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerGolpe > 0) timerGolpe -= Time.deltaTime;
        if (timerShoot > 0) timerShoot -= Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
        {
            
            if (attack != null)
            {
                if (attack.CanShoot())   
                {
                    attack.Shoot(firePoint);
                    isShooting = true;
                    timerShoot = Cooldown;
                }
                
                if (ActivateSpecialOnShoot) special.Activate();
            }
            else
            {
                if (DefaultAttack.CanShoot())
                {
                    DefaultAttack.Shoot();
                    if (!WithGun)
                    {
                        isHitting = true;
                        timerGolpe = Cooldown;
                    }
                    
                }
                if (ActivateSpecialOnShoot) special.Activate();
            }
            UpdateHUD();
        }

        if (timerGolpe < 0)
        {
            isHitting = false;
        }
        if (timerShoot < 0)
        {
            isShooting = false;
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
            

            switch (attack.Descripcion)
            {
                case "S & W PDW":
                    WithGun = true;
                    break;
					
					case "Particle Projection Cannon":
					break;
            }

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
        hud.UpdateWeapon(0, attack.Max_Ammo, attack.Descripcion, attack.img, attack.UsesAmmo);

        attack.TeleportObject(transform.position);

        attack = null;
        WithGun = false;
    }
}
