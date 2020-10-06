using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    [Header("Al Disparar")]
    public UnityEvent OnShoot;

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

    public bool CanShoot()
    {
        if (UsesAmmo)
        {
            return timer <= 0 && ammo > 0;
        }
        else
        {
            return timer <= 0;
        }
    }

    public void Shoot() //ataca desde el transform
    {
        if (IsMelee)
        {
            GameObject swing = Instantiate(bulletPrefab, transform.position + (transform.up * 0.8f), transform.rotation, gameObject.transform);
            swing.transform.SetParent(gameObject.transform, true);
        }
        else
        {
            Instantiate(bulletPrefab, transform.position + (transform.up * 0.8f), transform.rotation);
        }

        timer = Cooldown;

        OnShoot.Invoke();
    }

    public void Shoot(Transform firePoint) //ataca desde otro transform
    {
        if (IsMelee)
        {
            GameObject swing = Instantiate(bulletPrefab, firePoint.position + (firePoint.up * 0.8f), firePoint.rotation, firePoint);
            swing.transform.SetParent(firePoint, true);
        }
        else
        {
            Instantiate(bulletPrefab, firePoint.position + (firePoint.up * 0.8f), firePoint.rotation);
        }

        timer = Cooldown;

        OnShoot.Invoke();
    }

    public int GetAmmo() { return ammo; }
}
