using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Objeto Jugador

public class PlayerObject : MonoBehaviour, IHurtable
{
    public static PlayerObject Instance;

    [Header("Estadisticas Primarias")]
    public int HP_Max;

    private int hp;

    [Header("SubPartes")]
    public PlayerMovements movement;
    public PlayerAttack attack;

    [Header("UIs")]
    public GameObject Pause;

    bool paused = false;

    void Start()
    {
        hp = HP_Max;

        Instance = this;
    }

    void Update()
    {
        //pausa el juego e invoca el menu pausa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Continue();
            }
            else
            {
                Time.timeScale = 0;
                paused = true;
                Pause.SetActive(true);
            }
        }
    }

    public bool IsAlive() { return hp > 0; }

    public bool Hurt(int d)
    {
        hp -= d;

        if (hp <= 0)
        {
            Die();
            return true;
        }

        return false;
    }

    public void Heal(int h)
    {
        if (hp + h > 100)
        {
            hp = 100;
        }
        else
        {
            hp += h;
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        paused = false;
        Pause.SetActive(false);
    }
}
