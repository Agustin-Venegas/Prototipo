using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsManager : MonoBehaviour
{
    public Animator animator;
    public string currentState;

    public static PlayerAnimationsManager Instance;

    //Estados de la animacion
    const string PLAYER_IDLE_SIN_ARMAS = "Idle_SinArmas";
    const string PLAYER_WALK_SIN_ARMAS = "Walk_SinArmas";
    const string PLAYER_PUNCH = "Punch_SinArmas";
    const string PLAYER_IDLE_PISTOLA = "Idle";
    const string PLAYER_WALK_PISTOLA = "Walk";
    const string PLAYER_SHOOT_STATIC = "Static_Shoot";

    public bool isShooting = false;
    public bool WithGun = false;
    public bool isHitting = false;
    bool isWalking = false;

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
        /*isWalking = playerMovements.isWalking;
        isShooting = playerAttack.isShooting;
        isHitting = playerAttack.isHitting;
        WithGun = playerAttack.WithGun;*/

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
                    ChangeAnimationState(PLAYER_IDLE_SIN_ARMAS);
                }
                else
                {
                    ChangeAnimationState(PLAYER_WALK_SIN_ARMAS);
                }
            }
            else
            {
                ChangeAnimationState(PLAYER_PUNCH);
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
