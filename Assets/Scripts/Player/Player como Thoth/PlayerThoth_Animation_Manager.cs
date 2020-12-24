using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThoth_Animation_Manager : MonoBehaviour
{
    public Animator animator;
    public string currentState;

    public static PlayerThoth_Animation_Manager Instance;

    const string PLAYER_IDLE_SIN_ARMAS = "Idle_SinArmas";
    const string PLAYER_WALK_SIN_ARMAS = "Walk_SinArmas";
    const string PLAYERTHOTH_HIT = "PlayerThoth_Hit";

    PlayerMovements playerMovements;
    PlayerAttack playerAttack;

    void Start()
    {
        Instance = this;
        playerMovements = GameObject.FindObjectOfType<PlayerMovements>();
        playerAttack = GameObject.FindObjectOfType<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        
            
        if (!playerAttack.isHitting)
        {
            if (!playerMovements.isWalking)
            {
                ChangeAnimationState(PLAYER_IDLE_SIN_ARMAS);
            }
            else
            {
                ChangeAnimationState(PLAYER_WALK_SIN_ARMAS);
            }
        }
        else
        {
            ChangeAnimationState(PLAYERTHOTH_HIT);

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

