using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InstructionText : MonoBehaviour
{

    public Text text;

    public string write;

    public UnityEvent OnFinish;

    public string instruction;

    public bool finished_on_write = false;

    void Start()
    {
        
    }


    IEnumerator Type()
    {

        foreach (char c in write.ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(0.025f);
        }
    }

    void OnEnable()
    {
        text.text = "";

        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {
        if (text.text == write)
        {
            if (finished_on_write) OnFinish.Invoke();
        }
        if (Input.GetButtonDown(instruction))
        {
            OnFinish.Invoke();
        }
    }
}
