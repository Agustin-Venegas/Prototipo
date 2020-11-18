using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSkill : MonoBehaviour
{

    public int Unlocked = 1;
    public int[] levels;
    public GameObject[] prefabs;
    public GameObject[] buttons;

    public Transform WhereToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i< Unlocked; i++)
        {
            buttons[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(int s)
    {
        Instantiate(prefabs[s], WhereToSpawn);
        Destroy(gameObject);
    }
}
