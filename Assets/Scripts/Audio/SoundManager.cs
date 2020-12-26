using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 0.7f;
    [Range(0f, 1f)]
    public float pitch = 1f;

    [Range(0f, 0.5f)]
    public float randomVolume = 0.1f;
    [Range(0f, 0.5f)]
    public float randomPitch = 0.1f;

    public bool loop = false;

    private AudioSource source;

    public bool Check { get { return source.isPlaying; } }


    public void SetSource (AudioSource _source)
    {
        source = _source;
        source.clip = clip;
        source.loop = loop;
    }

    public void Play()
    {
        source.volume = volume * (1 + Random.Range(-randomVolume / 2f, randomVolume / 2f));
        source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));
        source.Play();
    }
	
	public void Play(float vol) 
	{
		source.volume = vol;
		source.Play();
	}
	
	public void Play(float vol, float p) 
	{
		source.volume = vol;
		source.pitch = p;
		source.Play();
	}

    public void Stop()
    {
        source.Stop();
    }


}

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;
	
	public bool mute = false;

    [SerializeField]
    Sound[] sounds;

    void Awake()
    {
         if(instance != null)
        {
            if (instance != this)
            {
                return;
            }
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            for (int i = 0; i < sounds.Length; i++)
            {
                GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
                sounds[i].SetSource(_go.AddComponent<AudioSource>());
                DontDestroyOnLoad(_go);
            }
            SceneManager.sceneLoaded += AlCargarEscena;
        }

    }

    void Start ()
    {
        
    }

    public void AlCargarEscena(Scene scene, LoadSceneMode loadSceneMode)
    {
        //Sonido del menu
        if (scene.name == "Intro")
        {
            if (sounds[1].Check == false)
            {
                PlaySound("Menu");
            }
        }
        else
        {
            if (!(scene.name == "Creditos" || scene.name == "Instrucciones" || scene.name == "NuevaPartida" || scene.name == "Cargar"))
            {
                StopSound("Menu");
            }
        }

        //Musica del primer nivel (Alcantarillas)
        if (scene.name == "Protipo Nivel")
        {
            if (sounds[2].Check == false)
            {
                PlaySound("Alcantarillas");
            }
        }
        else
        {
            StopSound("Alcantarillas");
        }

        //Musica del segundo nivel (Recuerdos de Thoth)
        if (scene.name == "Recuerdo Toth")
        {
            if (sounds[3].Check == false)
            {
                PlaySound("Recuerdo Thoth");
            }
        }
        else
        {
            StopSound("Recuerdo Thoth");
        }

        //Musica para el interludio entre los recuerdos de Thoth y la conversacion con Ares
        if (scene.name == "Reunion con Ares")
        {
            if (sounds[4].Check == false)
            {
                PlaySound("Interludio 1");
            }
        }
        else
        {
            StopSound("Interludio 1");
        }

        //Musica para la reunion con Ares
        if (scene.name == "Reunion con Ares Interludio")
        {
            if (sounds[5].Check == false)
            {
                PlaySound("Reunion Ares");
            }
        }
        else
        {
            StopSound("Reunion Ares");
        }

        //Musica para la mision que da Ares
        if (scene.name == "Reunion con Ares Mision")
        {
            if (sounds[6].Check == false)
            {
                PlaySound("Mision Ares");
            }
        }
        else
        {
            StopSound("Mision Ares");
        }

        //Musica para la habitacion blanca
        if (scene.name == "Habitacion Blanca")
        {
            if (sounds[6].Check == false)
            {
                PlaySound("Habitacion Blanca");
            }
        }
        else
        {
            StopSound("Habitacion Blanca");
        }
    }

    public void PlaySound (string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                if (!mute) sounds[i].Play();
                return;
            }
        }

        Debug.LogWarning("AudioManager: Sound not found in list. " + _name);
    }
	
	
	public void PlaySound (string _name, float v)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                if (!mute) sounds[i].Play(v);
                return;
            }
        }

        Debug.LogWarning("AudioManager: Sound not found in list. " + _name);
    }

    public void StopSound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Stop();
                return;
            }
        }

        Debug.LogWarning("AudioManager: Sound not found in lis. " + _name);
    }
}
