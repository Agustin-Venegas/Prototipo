using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


//esta cosa debe ser un objeto q no se destruye
//almacena info del juego y los saves

public class Game : MonoBehaviour
{

    public static Game Instance;

    public GameSave ActiveSave;

    [Header("Vars")]
    public int active_index;

    [Header("SaveData")]
	public string name;
    public int Desbloqueos = 1;
    public List<float> TiempoNivel = new List<float>(); //almacena los tiempos de cada nivel
    public string lastScene = null; //checkpoints

    public GameSave save1;
    public GameSave save2;
    public GameSave save3;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //nos aseguramos de no matarlo

            //cargar saves a la memoria
            save1 = LoadFromJason("save1");
            save2 = LoadFromJason("save2");
            save3 = LoadFromJason("save3");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveToActive()
    {
        ActiveSave.Desbloqueos = Desbloqueos;
        ActiveSave.TiempoNivel = TiempoNivel;
		lastScene = SceneManager.GetActiveScene().name;
		ActiveSave.lastScene = lastScene;
		
        SaveIntoJason("save"+active_index);
    }
	
	public void SaveToActive(string s)
    {
        ActiveSave.Desbloqueos = Desbloqueos;
        ActiveSave.TiempoNivel = TiempoNivel;
		lastScene = s;
		ActiveSave.lastScene = lastScene;
		
        SaveIntoJason("save"+active_index);
    }

    public void LoadActive()
    {
		name = ActiveSave.name;
        Desbloqueos = ActiveSave.Desbloqueos;
        TiempoNivel = ActiveSave.TiempoNivel;
		lastScene = ActiveSave.lastScene;
    }

    public bool SaveIntoJason(string filename)
    {
        string data = JsonUtility.ToJson(ActiveSave);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/" + filename+ ".json", data);

        return true; //esto no deberia fallar como nunca
    }

    public GameSave LoadFromJason(string filename)
    {
        string data;
        GameSave save = null;
        try
        { 
            data = System.IO.File.ReadAllText(Application.persistentDataPath + "/" + filename + ".json");
        }
        catch (Exception e)
        {
            return null; //funciona mal
        }
        save = JsonUtility.FromJson<GameSave>(data);

        return save; //funciona bien
    }

    public void SelectActive(int i)
    {

        active_index = i;

        switch (i)
        {
            case 1:
                ActiveSave = save1;
                break;

            case 2:
                ActiveSave = save2;
                break;

            case 3:
                ActiveSave = save3;
                break;
        }
    }
}
