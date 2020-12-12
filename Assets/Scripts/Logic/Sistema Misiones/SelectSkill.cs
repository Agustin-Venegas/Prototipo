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
	
	public CamControl cam;

    // Start is called before the first frame update
    void OnEnable()
    {
        for (int i = 0; i< buttons.Length; i++)	
        {
            buttons[i].SetActive( i<= Unlocked);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(int s)
    {
        GameObject g = Instantiate(prefabs[s], WhereToSpawn.position, WhereToSpawn.rotation);
		cam.follow = g.transform;
        Destroy(gameObject);
    }
}
