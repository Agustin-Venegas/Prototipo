using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [Header("Vars Jugador")]
    public Text health;

    [Header("Ataque")]
    public bool AttackOn = false;
    public GameObject WeaponPanel;
    public Text ammo;
    public Text fluff;
    public Image wep;

    [Header("Habilidad Especial")]
    public bool SpecialOn = false;
    public GameObject SpecialPanel;
    public Text cooldown;
    public Image specialImg;

    // Start is called before the first frame update
    void Start()
    {
        WeaponPanel.SetActive(AttackOn);
        SpecialPanel.SetActive(SpecialOn);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateWeapon(int am, int max_ammo, string desc, Sprite w, bool uses_Ammo)
    {
        if (am > 0)
        {
            if (!AttackOn)
            {
                AttackOn = true;
                WeaponPanel.SetActive(true);
            }

            if (uses_Ammo) ammo.text = am + " / " + max_ammo;
            else ammo.enabled = false;

            fluff.text = desc;
            wep.sprite = w;
        }
        else
        {
            AttackOn = false;
            WeaponPanel.SetActive(false);
        }
    }

    public void UpdateWeapon(int am, int max_ammo)
    {
        ammo.text = am + " / " + max_ammo;
    }
    public void UpdateHealth(int hp, int max)
    {
        float num = ((float)hp / (float)max) * 100;

        health.text = "health " + num + "%";
        if (hp == 0) health.text = "energy critical";
    }
}
