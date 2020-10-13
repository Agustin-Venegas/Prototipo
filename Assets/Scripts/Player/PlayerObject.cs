using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public HUD hud;
    public GameObject Pause;
    public GameObject Death;

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

        hud.UpdateHealth(hp, HP_Max);

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

        hud.UpdateHealth(hp, HP_Max);
    }

    public void Die()
    {
        gameObject.SetActive(false);
        Instantiate(Death);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        paused = false;
        Pause.SetActive(false);
    }
}
