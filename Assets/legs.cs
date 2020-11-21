using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legs : MonoBehaviour
{
    public Animator animator;
    const string PLAYER_LEGS_IDLE = "Legs_Stop";
    const string PLAYER_LEGS_WALK = "Legs";

    public string currentState;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = GetComponentInParent<Transform>().rotation;

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D))
        {
            ChangeAnimationState(PLAYER_LEGS_WALK);
        }
        else
        {
            ChangeAnimationState(PLAYER_LEGS_IDLE);
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
