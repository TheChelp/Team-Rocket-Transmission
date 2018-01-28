<<<<<<< HEAD
﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
=======
﻿﻿using UnityEngine;
>>>>>>> 94ff81ba42c89d667ed630b25ea9faff5158dc64

public class SpriteActions : MonoBehaviour
{

    public float Speed;
    public float Offset = 0;

    private int _dx, _dy;
    public  GameObject FlashLight;
    private Vector3 _rotationAngles;
    private Animator _animator;

    // Use this for initialization
    void Start () {
        _rotationAngles = new Vector3();
        _animator = gameObject.GetComponent<Animator>();

        if (FlashLight != null)
            _rotationAngles = FlashLight.transform.eulerAngles;

        if (Speed == 0.0f)
        {
            Debug.Log("<color=yellow> Warning: Speed is zero. Character will not move </color>");
        }

        if (FlashLight == null)
        {
            Debug.Log("Flashlight not found :(");
        }
    }
	
	// Update is called once per frame
	void Update ()
	{
        if (Input.GetKey(KeyCode.W))
	    {
	        _dy++;
	    }
	    if (Input.GetKey(KeyCode.S))
	    {
	        _dy--;
	    }
	    if (Input.GetKey(KeyCode.A))
	    {
	        _dx--;
	    }
	    if (Input.GetKey(KeyCode.D))
	    {
	        _dx++;
        }

	    if (FlashLight != null)
	    {
	        Vector3 d =  Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position; 
	        Debug.Log("d = " + d);

            Vector2 dist = new Vector2(d.x,d.y);
            dist.Normalize();
	        float angle = Mathf.Rad2Deg * -Mathf.Atan2(dist.y,dist.x);
            Debug.Log(angle + " Degrees");
            FlashLight.transform.eulerAngles = new Vector3(angle,90,0);

	    }

	    float velocityX = _dx * Speed;
	    float velocityY = _dy * Speed;

	    if (_animator != null)
	    {
	        _animator.SetFloat("velocityX", velocityX);
            _animator.SetFloat("velocityY", velocityY);
	    }

        gameObject.transform.position += new Vector3(velocityX,velocityY ,0);
	    _dx = 0;
	    _dy = 0;

	}

}
