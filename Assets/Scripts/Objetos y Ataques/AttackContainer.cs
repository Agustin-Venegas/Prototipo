using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//muy parecido al PlayerAttack, deberia hacer una clase/struct ataque
//esta se diferencia en que los enemigos la utilizan tambien

public class AttackContainer : MonoBehaviour
{
    [Header("Objeto a Spawnear")]
    public GameObject bulletPrefab;
    public bool IsMelee; //si es melee, va a querer acercarse al jugador antes de atacar

    [Header("Variables del ataque")]
    public float Cooldown = 0.5f;
    public bool UsesAmmo = false; //si el ataque usa municion
    public int Max_Ammo; //solo se usa si el bool anterior es true

    int ammo;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (UsesAmmo) ammo = Max_Ammo;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
    }

    public int GetAmmo() { return ammo; }
}
