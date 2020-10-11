using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBehaviour : MonoBehaviour
{
    public void Return()
    {
        PlayerObject.Instance.Continue();
    }
}
