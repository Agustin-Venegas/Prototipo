using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//esta habilidad hace que el tiempo se ralentize, por 5 segundos
public class CorteTemporal : MonoBehaviour, HabilidadConCooldown
{

    public static CorteTemporal Instance = null;

    public float SpeedRatioToWorld = 0.3f;
    public float SpeedRatioToPlayer = 2f;
    public float Tiempo = 5f;
    public float Cooldown = 15f;

    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {

        SceneManager.sceneUnloaded += OnSceneUnloaded; //nos seguramos q no se rompa

        if (CorteTemporal.Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            CorteTemporal.Instance = this;
        }

        Time.timeScale = SpeedRatioToWorld;
        PlayerMovements.Instance.maxSpeed *= SpeedRatioToPlayer;
    }

    private void OnSceneUnloaded(Scene actual)
    {
        Time.timeScale = 1.0f; //nos aseguramos de no romper nada
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= Tiempo)
        {
            End();
        }
    }

    void End()
    {
        Time.timeScale = 1.0f;
        PlayerMovements.Instance.maxSpeed /= SpeedRatioToPlayer;

        CorteTemporal.Instance = null;

            Destroy(gameObject);
    }

    public float GetCooldown()
    {
        return Cooldown;
    }
}
