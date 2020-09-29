using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBasedMenu : MonoBehaviour
{
    int selected;

    public MenuItem[] list;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            if (selected > 0) selected--; else  selected = list.Length-1;

        if (Input.GetKeyDown(KeyCode.DownArrow)) 
            if (selected < list.Length-1) selected++; else selected = 0;

        if (Input.GetKeyDown(KeyCode.Space)) list[selected].Do();
    }
}
