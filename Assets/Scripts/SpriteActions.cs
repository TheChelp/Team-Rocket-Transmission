using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	        if (FlashLight != null)
	        {
                Debug.Log("Flashlight Up!");
	            FlashLight.transform.eulerAngles = new Vector3(-90, _rotationAngles.y, _rotationAngles.z);
                FlashLight.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + Offset, FlashLight.transform.position.z);
            }
	    }
	    if (Input.GetKey(KeyCode.S))
	    {
	        _dy--;
	        if (FlashLight != null)
	        {
	            FlashLight.transform.eulerAngles = new Vector3(90, _rotationAngles.y, _rotationAngles.z);
                FlashLight.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - Offset, FlashLight.transform.position.z);
            }
	    }
	    if (Input.GetKey(KeyCode.A))
	    {
	        _dx--;
	        if (FlashLight != null)
	        {
	            FlashLight.transform.eulerAngles = new Vector3(180, _rotationAngles.y, _rotationAngles.z);
                FlashLight.transform.position = new Vector3(gameObject.transform.position.x - Offset, gameObject.gameObject.transform.position.y, FlashLight.transform.position.z);
            }
	    }
	    if (Input.GetKey(KeyCode.D))
	    {
	        _dx++;
	        if (FlashLight != null)
	        {
	            FlashLight.transform.eulerAngles = new Vector3(0, _rotationAngles.y, _rotationAngles.z);
                FlashLight.transform.position = new  Vector3(gameObject.transform.position.x + Offset,gameObject.gameObject.transform.position.y, FlashLight.transform.position.z);
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
