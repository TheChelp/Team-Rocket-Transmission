using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpriteActions : MonoBehaviour
{

    public float Speed;
    public float Offset = 0;

    private int _dx, _dy;
    private Light _flashLight;
    private Vector3 _rotationAngles;


    // Use this for initialization
    void Start () {
        _flashLight = gameObject.GetComponentInChildren<Light>();
        _rotationAngles = new Vector3();

        if (_flashLight != null)
            _rotationAngles = _flashLight.transform.eulerAngles;

        if (Speed == 0)
        {
            Debug.Log("<color=yellow> Warning: Speed is zero. Character will not move </color>");
        }

        if (_flashLight == null)
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
	        if (_flashLight != null)
	        {
	            _flashLight.transform.eulerAngles = new Vector3(-90, _rotationAngles.y, _rotationAngles.z);
                _flashLight.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + Offset, _flashLight.transform.position.z);
            }
	    }
	    if (Input.GetKey(KeyCode.S))
	    {
	        _dy--;
	        if (_flashLight != null)
	        {
	            _flashLight.transform.eulerAngles = new Vector3(90, _rotationAngles.y, _rotationAngles.z);
                _flashLight.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - Offset, _flashLight.transform.position.z);
            }
	    }
	    if (Input.GetKey(KeyCode.A))
	    {
	        _dx--;
	        if (_flashLight != null)
	        {
	            _flashLight.transform.eulerAngles = new Vector3(180, _rotationAngles.y, _rotationAngles.z);
                _flashLight.transform.position = new Vector3(gameObject.transform.position.x - Offset, gameObject.gameObject.transform.position.y, _flashLight.transform.position.z);
            }
	    }
	    if (Input.GetKey(KeyCode.D))
	    {
	        _dx++;
	        if (_flashLight != null)
	        {
	            _flashLight.transform.eulerAngles = new Vector3(0, _rotationAngles.y, _rotationAngles.z);
                _flashLight.transform.position = new  Vector3(gameObject.transform.position.x + Offset,gameObject.gameObject.transform.position.y, _flashLight.transform.position.z);
            }
	        

        }


	    gameObject.transform.position += new Vector3(_dx * Speed, _dy * Speed,0);
	    _dx = 0;
	    _dy = 0;

	}


}
