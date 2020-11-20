using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//clase de savegames
[System.Serializable]
public class GameSave
{

    public int Desbloqueos = 1; //4 es el maximo
    public List<float> TiempoNivel = new List<float>(); //almacena los tiempos de cada nivel
    public string lastScene = null;

    public static GameSave InstanciaActiva;

    public GameSave()
    {
        InstanciaActiva = this;
    }

    public string CrearJason()
    {
        string s = JsonUtility.ToJson(this);
        return s;
    }
}
