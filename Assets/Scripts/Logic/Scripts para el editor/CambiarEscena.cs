using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//script para cambiar escena
//en el editor se puede poner en un objeto
//y se le puede poner el nombre de la escena objetivo

public class CambiarEscena : MonoBehaviour
{
    public string Escena;
    
    public void Cambiar(string s)
    {
        SceneManager.LoadScene(s);
    }

    public void cambiar()
    {
        SceneManager.LoadScene(Escena);
    }
}
