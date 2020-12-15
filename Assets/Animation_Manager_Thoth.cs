using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Manager_Thoth : MonoBehaviour
{
    public Animator animator;
    public string currentState;

    public static Animation_Manager_Thoth Instance;

    //Estados de la animacion
    const string PLAYER_IDLE_SIN_ARMAS = "Idle_SinArmas";
    const string PLAYER_WALK_SIN_ARMAS = "Walk_SinArmas";
    const string PLAYER_PUNCH = "Punch_SinArmas";
    const string PLAYER_IDLE_PISTOLA = "Idle";
    const string PLAYER_WALK_PISTOLA = "Walk";
    const string PLAYER_SHOOT_STATIC = "Static_Shoot";
    const string THOTH_IDLE = "Thoth_Idle";
    const string THOTH_HIT = "Thoth_Hit";
    const string THOTH_WLAK = "Thoth_Walk";

    PlayerMovements playerMovements;
    PlayerAttack playerAttack;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        playerMovements = GameObject.FindObjectOfType<PlayerMovements>();
        playerAttack = GameObject.FindObjectOfType<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAttack.WithGun)
        {
            if (!playerAttack.isShooting)
            {
                if (playerMovements.isWalking)
                {
                    ChangeAnimationState(PLAYER_WALK_PISTOLA);
                }
                else
                {
                    ChangeAnimationState(PLAYER_IDLE_PISTOLA);
                }
            }
            else
            {
                ChangeAnimationState(PLAYER_SHOOT_STATIC);
            }

        }
        else
        {
            if (!playerAttack.isHitting)
            {
                if (!playerMovements.isWalking)
                {
                    ChangeAnimationState(THOTH_IDLE);
                }
                else
                {
                    ChangeAnimationState(THOTH_WLAK);
                }
            }
            else
            {
                ChangeAnimationState(THOTH_HIT);
            }
        }


    }

    void ChangeAnimationState(string newState)
    {
        //Detener la animacion para que no se interrumpa ella misma
        if (currentState == newState) return;

        //Ejecutar la animacion
        animator.Play(newState);

        //Reasignar la animacion ejecutandoce
        currentState = newState;
    }
}
