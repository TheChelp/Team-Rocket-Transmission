﻿using System;
 using System.Collections;
 using UnityEngine;

public class SpriteActions : MonoBehaviour
{

    public float Speed;
    public float Offset = 0;

    private int _dx, _dy;
    public  GameObject FlashLight;
    private Vector3 _rotationAngles;
    private Animator _animator;
    public GameObject wavePrefab;
    public bool autoscript;

    // Use this for initialization
    void Start () {
        _rotationAngles = new Vector3();
        _animator = gameObject.GetComponent<Animator>();


        if (autoscript)
        {
            StartCoroutine(tutorialScript());
        }
        else
        {
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
        
    }

    public IEnumerator tutorialScript()
    {
        right = true;

        yield return null;
    }
	// Update is called once per frame
    private bool up, down, right, left;
	void Update ()
	{
	    if (!autoscript)
	    {
	        if (Input.GetKey(KeyCode.W) )
	        {
	            _dy++;
	        }
	        if (Input.GetKey(KeyCode.S) )
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
	    }
	    else
	    {
            if (up)
            {
                _dy++;
            }
            if (down)
            {
                _dy--;
            }
            if (left)
            {
                _dx--;
            }
            if (right)
            {
                _dx++;
            }
        }

	    if (!autoscript && FlashLight != null)
	    {
	        Vector3 d =  Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position; 

            Vector2 dist = new Vector2(d.x,d.y);
            dist.Normalize();
	        float angle = Mathf.Rad2Deg * -Mathf.Atan2(dist.y,dist.x);
            FlashLight.transform.eulerAngles = new Vector3(angle,90,0);

            if (Input.GetMouseButtonDown(0))
            {
                GameObject wave = Instantiate(wavePrefab);
                wave.name = "Wave";
                wave.GetComponent<WaveActions>().Velocity = new Vector3(dist.x,dist.y,0);
                wave.GetComponent<WaveActions>().transform.eulerAngles = new Vector3(0, 0, -angle);
                wave.GetComponent<WaveActions>().transform.position += new Vector3(gameObject.transform.position.x + 1.5f * dist.x, gameObject.transform.position.y + 1.5f * dist.y,0);
                wave.GetComponent<WaveActions>().transform.localScale = new Vector3(0.25f,0.25f,0.25f); 

            }

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
