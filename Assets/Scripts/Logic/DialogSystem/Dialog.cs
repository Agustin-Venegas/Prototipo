using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMPro;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{

    public TextMeshProGUI disp;
    public string[] Sentences;  //frases
    public Sprite[] TalkingHeads; //imagen q aparece, puede ser null
    public float CharSpeed = 0.2f;

    public GameObject Boton;
        
    int index;

    IEnumerator Type()
    {
        foreach (char c in Sentences[index].ToCharArray())
        {
            disp.text += c;
            yield return new WaitForSeconds(CharSpeed);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {
        if (disp.text == Sentences[index])
        {
            Boton.SetActive(true);
        }
    }

    public void Avanzar()
    {
        Boton.SetActive(false);

        if (index < Sentences.Length -1)
        {
            index++;
            disp.text = "";
            StartCoroutine(Type());
        }
        else
        {
            disp.text = "";
            Boton.SetActive(false);
        }
    }
}
