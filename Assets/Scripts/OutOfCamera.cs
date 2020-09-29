using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfCamera : MonoBehaviour
{
    private void OnBecameInvisible()    //Si está fuera de cualquier cámara visible.
    {
        Destroy(gameObject);    //Se destruye a si mismo.
    }
}
