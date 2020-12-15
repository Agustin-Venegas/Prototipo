using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Manager_Thoth : MonoBehaviour
{
    public Animator animator;
    public string currentState;

    public static Animation_Manager_Thoth Instance;

    //Estados de la animacion
    const string THOTH_IDLE = "Idle";
    const string THOTH_HIT = "Hit";
    const string THOTH_WLAK = "Walk";

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

        if (!playerAttack.isHitting)
        {
            if (playerMovements.isWalking)
            {
                ChangeAnimationState(THOTH_WLAK);
                    
            }
            else
            {
                ChangeAnimationState(THOTH_IDLE);
            }
        }
        else
        {
            ChangeAnimationState(THOTH_HIT);
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
