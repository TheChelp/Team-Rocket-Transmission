using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteActions : MonoBehaviour
{

    public float speed;
    private int dx, dy;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (gameObject != null)
	    {
	        if (Input.GetKey(KeyCode.W))
	            dy++;
	        if (Input.GetKey(KeyCode.S))
	            dy--;
	        if (Input.GetKey(KeyCode.A))
	            dx--;
	        if (Input.GetKey(KeyCode.D))
	            dx++;
	       
	        gameObject.transform.position += new Vector3(dx * speed, dy * speed,0);
	        dx = 0;
	        dy = 0;

	    }



	}


}
