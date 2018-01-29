﻿using System;
 using System.Collections;
 using UnityEngine;
 using UnityEngine.SceneManagement;

public class SpriteActions : MonoBehaviour
{

    public float Speed;
    public float Offset = 0;
    public int read = 0;
    private int _dx, _dy;
    public  GameObject FlashLight;
    private Vector3 _rotationAngles;
    private Animator _animator;
    public GameObject wavePrefab;
    public bool autoscript = false;

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

    public void PausePlayer()
    {
        autoscript = true;
    }
    public void Unpause()
    {
        autoscript = false;
        Debug.Log("Unpause");
        read++;
    }

    public IEnumerator tutorialScript()
    {
        right = true;

        yield return new WaitForSeconds(9);
        right = false;
        


    }

    public IEnumerator ToDoor()
    {
        left = true;
        yield return new WaitForSeconds(4.8f);
        left = false;
        up = true;
        yield return new WaitForSeconds(0.5f);
        up = false;
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Scenes/Level2");
    }
    // Update is called once per frame
    private bool up, down, right, left;
	void Update ()
	{
	    autoscript = false;
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
