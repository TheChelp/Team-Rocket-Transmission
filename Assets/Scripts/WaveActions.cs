using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveActions : MonoBehaviour
{

    public Vector3 Velocity;
    public float WaveSpeed;
    private Vector3 lastPosition = new Vector3();
    public SpriteRenderer SpriteRenderer;
    public float Duration;
	// Use this for initialization
	void Start ()
	{
        Velocity.Normalize();
	    Velocity *= WaveSpeed;
        Physics2D.IgnoreCollision(GameObject.Find("Player").GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private float elapsed = 0.0f;
	// Update is called once per frame
	void Update ()
	{
	    elapsed += Time.deltaTime;
        //Debug.Log("elapsed: " + elapsed + " / " + Duration);
	    if (elapsed > Duration)
        {
	        gameObject.transform.parent = null;
	        Destroy(gameObject.transform.GetChild(0).gameObject);
            gameObject.transform.DetachChildren();
            Destroy(gameObject);
	    }
	   
	    gameObject.transform.position += Velocity * Time.deltaTime;
	}

    private IEnumerator delayBeforeStop()
    {
        yield return new WaitForSeconds(0.1f);
        Velocity = new Vector3(0, 0, 0);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(delayBeforeStop());
    }
}
