using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FadeScene : MonoBehaviour
{
	
	public GameObject cuadrao;
	public UnityEvent OnFinish;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void StartFade(bool pa_negro) 
	{
		Task t = new Task(Cambiar(pa_negro,1));
		t.Finished += delegate(bool man) 
		{
			OnFinish.Invoke();
		};
	}
	
	public IEnumerator Cambiar(bool pa_negro = true, int speed = 5) 
	{
		Color c = cuadrao.GetComponent<Image>().color;
		float amount;
		
		if (pa_negro) 
		{
			while (cuadrao.GetComponent<Image>().color.a < 1) 
			{
				amount = c.a + (speed * Time.deltaTime);
				
				c = new Color(c.r, c.g, c.b, amount);
				cuadrao.GetComponent<Image>().color = c;
				yield return null;
			}
			
			OnFinish.Invoke();
		} else 
		{
			while (cuadrao.GetComponent<Image>().color.a > 0) 
			{
				amount = c.a - (speed * Time.deltaTime);
				
				c = new Color(c.r, c.g, c.b, amount);
				cuadrao.GetComponent<Image>().color = c;
				yield return null;
			}
			
			OnFinish.Invoke();
		}
	}
}
