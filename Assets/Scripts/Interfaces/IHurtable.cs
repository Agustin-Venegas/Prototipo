using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Todo lo que es dañable implementa esto

public interface IHurtable
{
    bool IsAlive();

    bool Hurt(int d);

    void Die();
}
