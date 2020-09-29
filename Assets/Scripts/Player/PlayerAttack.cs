using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//esto se encarga de contener el ataque del jugador
//y de activarlo con una tecla

public class PlayerAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position + (firePoint.transform.up * 0.8f), firePoint.rotation);
        Rigidbody2D rgb2 = bullet.GetComponent<Rigidbody2D>();
        rgb2.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
