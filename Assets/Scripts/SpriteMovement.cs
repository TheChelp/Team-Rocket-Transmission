using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpriteMovement : MonoBehaviour
{

    public enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    };

    public string name;
    public KeyCode
        UpCode = KeyCode.W, 
        DownCode = KeyCode.S, 
        LeftCode = KeyCode.A, 
        RightCode = KeyCode.D;

    public float Speed;
    public bool EnableKeys = true;


    private float _dx, _dy;
    private float _lastX, _lastY;


	// Use this for initialization
	void Start ()
	{
	    if (name == null)
	        name = gameObject.name;

        if (Math.Abs(Speed) < 0.000001f)
        {
            Debug.Log("<color=yellow> Warning: Speed of " + name + " is zero. " +
                      "Character will not move </color>");
        }
    }
	
	// Update is called once per frame
	void Update ()
	{
	    _lastX = _dx;
	    _lastY = _dy;

        if (EnableKeys)
	    {
	        if (Input.GetKey(LeftCode))
	            MoveLeft();
            if (Input.GetKey(RightCode))
                MoveRight();
            if (Input.GetKey(UpCode))
                MoveUp();
            if (Input.GetKey(DownCode))
                MoveDown();
        }

        gameObject.transform.position += new Vector3(_dx,_dy, 0);
        _dx = _dy = 0.0f;
    }

    public void MoveLeft()
    {
        _dx -= Speed * Time.deltaTime;
    }

    public void MoveRight()
    {
        _dx += Speed * Time.deltaTime;
    }

    public void MoveUp()
    {
        _dy += Speed * Time.deltaTime;
    }

    public void MoveDown()
    {
        _dy -= Speed * Time.deltaTime;
    }


    public IEnumerator MoveFor(Direction direction, float duration)
    {

        for(float timer = duration; timer > 0.0f; timer -= Time.deltaTime)
        {
            switch (direction)
            {
                case Direction.LEFT:
                    MoveLeft();
                    break;
                case Direction.RIGHT:
                    MoveRight();
                    break;
                case Direction.UP:
                    MoveUp();
                    break;
                case Direction.DOWN:
                    MoveDown();
                    break;
            }
            
            yield return null;
        } 
    }

    public float GetVelX()
    {
        return _lastX;
    }
    public float GetVelY()
    {
        return _lastY;
    }
}
