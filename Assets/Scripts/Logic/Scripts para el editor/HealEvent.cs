using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEvent : MonoBehaviour
{

    public int HP = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HealPlayer()
    {
        if (PlayerObject.Instance != null)
        {
            PlayerObject.Instance.Heal(HP);
        }
    }
}
