using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Objeto Jugador
//debe tener las variables que todas las "clases" o roles tienen

public class PlayerObject : MonoBehaviour, IHurtable
{
    public static PlayerObject Instance;

    [Header("Estadisticas Primarias")]
    public int HP_Max;
    public int Energy_Max;
    //public int Hunger_Max;

    private int hp;
    private int energy;
    public int GetEnergy() { return energy; }
    public void SetEnergy(int e) { energy = e; }
    public void UseEnergy(int e) { energy -= e; }
    //private int hunger;

    [Header("SubPartes")]
    public PlayerMovements movement;
    public PlayerAttack attack;
    public PlayerSpells spell;

    [Header("UIs")]
    public GameObject Pause;
    public GameObject Inventario;

    bool paused = false;

    void Start()
    {
        hp = HP_Max;
        energy = Energy_Max;

        Instance = this;
    }

    void Update()
    {
        //pausa el juego e invoca el menu pausa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Inventario.activeSelf) //salir del inventario si esta prendido
            {
                Inventario.SetActive(false);
                attack.enabled = true;
            } else
            {
                if (paused)
                {
                    Time.timeScale = 1;
                    paused = false; 
                    Pause.SetActive(false);
                }
                else
                {
                    Time.timeScale = 0;
                    paused = true;
                    Pause.SetActive(true);
                }
            }
        }

        //Activa/desactiva el Inventario
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            if (Inventario.activeSelf) 
            {
                Inventario.SetActive(false);
                attack.enabled = true; //y la capacidad de atacar
            } else 
            {
                Inventario.SetActive(true);
                attack.enabled = false;
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

    public void Die()
    {
        //aqui tiene que ir lo que se activa cuando muere
    }
}
