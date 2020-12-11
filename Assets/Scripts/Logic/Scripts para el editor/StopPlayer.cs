using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void Stop() 
	{
		GameObject g = PlayerObject.Instance.gameObject;
		
		g.GetComponent<PlayerMovements>().enabled = false;
		g.GetComponent<PlayerAttack>().enabled = false;
	}
	
	public void EnablePlayer() 
	{
		GameObject g = PlayerObject.Instance.gameObject;
		
		g.GetComponent<PlayerMovements>().enabled = true;
		g.GetComponent<PlayerAttack>().enabled = true;
	}
	
	public void EnablePlayer(bool i) 
	{
		if (PlayerObject.Instance != null) 
		{
			GameObject g = PlayerObject.Instance.gameObject;
		
			g.GetComponent<PlayerMovements>().enabled = i;
			g.GetComponent<PlayerAttack>().enabled = i;
		}
	}
}
