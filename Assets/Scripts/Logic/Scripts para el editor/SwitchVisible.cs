using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchVisible : MonoBehaviour
{
    public GameObject obj;

    public void Switch()
    {
        obj.SetActive(!obj.active);
    }
}
