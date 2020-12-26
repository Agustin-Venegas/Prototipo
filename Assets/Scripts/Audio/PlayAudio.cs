using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
	
	public string sound;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void Play() 
	{
		SoundManager.instance.PlaySound(name);
	}
	
	public void PlaySound(string s) 
	{
		SoundManager.instance.PlaySound(s);
	}
	
	public void PlaySoundWithVolume(float v) 
	{
		SoundManager.instance.PlaySound(sound, v);
	}
}
