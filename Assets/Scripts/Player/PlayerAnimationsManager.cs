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
    const string PLAYER_SNIPER_SHOOT = "Sniper_Shoot";
    const string PLAYER_SNIPER_WALK = "Sniper_Walk";
    const string PLAYER_SNIPER_IDLE = "Sniper_Idle";

    PlayerMovements playerMovements;
    PlayerAttack playerAttack;

    private SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        playerMovements = gameObject.GetComponent<PlayerMovements>();
        playerAttack = gameObject.GetComponent<PlayerAttack>();

        soundManager = SoundManager.instance;
        if (soundManager == null)
        {
            Debug.LogError("No audio manager founded in the scene");
        }
    }

    // Update is called once per frame
    void Update()
    {

        switch (playerAttack.WithWeapon)
        {
            case 0:
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
                    //soundManager.PlaySound("Punch1");
                }
                break;

            case 1:
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
                break;

            case 2:
                if (!playerAttack.isShooting)
                {
                    if (playerMovements.isWalking)
                    {
                        ChangeAnimationState(PLAYER_SNIPER_WALK);
                    }
                    else
                    {
                        ChangeAnimationState(PLAYER_SNIPER_IDLE);
                    }
                }
                else
                {
                    ChangeAnimationState(PLAYER_SNIPER_SHOOT);
                }
                break;
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
