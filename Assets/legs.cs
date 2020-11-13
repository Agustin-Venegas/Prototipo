using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legs : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = GetComponentInParent<Transform>().rotation;

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Speed", true);
        }
        else
        {
            animator.SetBool("Speed", false);
        }
    }
}
