using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//esto hace lo de sobreescribir/guardar
public class NewGameUI : MonoBehaviour
{
	
	public Text nameInput;

    [Header("Botones")]
    public Button Boton1;
    public Button Boton2;
    public Button Boton3;

	[Header("Titulos")]
    public Text tit1;
    public Text tit2;
    public Text tit3;

    [Header("Textos")]
    public Text info1;
    public Text info2;
    public Text info3;

    void Start()
    {
        if (Game.Instance.save1 != null && Game.Instance.save1.lastScene != "")
        {
			tit1.text = Game.Instance.save1.name;
            info1.text = Game.Instance.save1.CrearJason();
        }
        else
        {
            info1.text = "NO SAVE DATA";
        }

        if (Game.Instance.save2 != null && Game.Instance.save2.lastScene != "")
        {
			tit2.text = Game.Instance.save2.name;
            info2.text = Game.Instance.save2.CrearJason();
        }
        else
        {
            info2.text = "NO SAVE DATA";
        }

        if (Game.Instance.save3 != null && Game.Instance.save3.lastScene != "")
        {
			tit3.text = Game.Instance.save3.name;
            info3.text = Game.Instance.save3.CrearJason();
        }
        else
        {
            info3.text = "NO SAVE DATA";
        }
    }


    void Update()
    {
        
    }

    public void Select(int i)
    {
        switch (i)
        {
            case 1:
                Game.Instance.save1 = new GameSave();
				Game.Instance.save1.name = nameInput.text;
                break;
            case 2:
                Game.Instance.save2 = new GameSave();
				Game.Instance.save2.name = nameInput.text;
                break;
            case 3:
                Game.Instance.save3 = new GameSave();
				Game.Instance.save3.name = nameInput.text;
                break;
        }

        Game.Instance.SelectActive(i);

        SceneManager.LoadScene("CasaIntro");
    }
}
