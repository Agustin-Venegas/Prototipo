using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public Vector3 offset;
    public Transform follow = null;

    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {

        if (follow != null) 
		{
			transform.position = follow.position + offset;

			if (Input.GetKey("left shift"))
			{

				Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
				screenPosition = Camera.main.ScreenToWorldPoint(screenPosition);


				transform.position = follow.position + offset + (screenPosition-transform.position);
			}
		}
    }
}
