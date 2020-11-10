using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuItem : MonoBehaviour
{

    public UnityEvent OnHover;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void Do()
    {

    }

    void OnMouseEnter()
    {
        OnHover.Invoke();
    }
}
