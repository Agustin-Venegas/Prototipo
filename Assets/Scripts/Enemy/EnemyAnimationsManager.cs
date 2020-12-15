using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationsManager : MonoBehaviour
{
    public Animator animator;
    public string currentState;

    public static EnemyAnimationsManager Instance;

    //Estados de la animacion
    const string ENEMY_IDLE = "Idle";
    const string ENEMY_WALK = "Walk";
    const string ENEMY_DEAD = "Corpse";
    const string ENEMY_SHOOT = "Shoot";

    EnemyObject enemyObject;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        enemyObject = gameObject.GetComponent<EnemyObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!enemyObject.IsDead)
        {
            if (enemyObject.WithGun)
            {
                if (enemyObject.isShooting)
                {
                    ChangeAnimationState(ENEMY_SHOOT);
                }
            }
            else if (enemyObject.isWalking)
            {
                ChangeAnimationState(ENEMY_WALK);
            }
            else if (!enemyObject.isWalking && !enemyObject.WithGun)
            {
                ChangeAnimationState(ENEMY_IDLE);
            }
        }

        else
        {
            ChangeAnimationState(ENEMY_DEAD);
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
