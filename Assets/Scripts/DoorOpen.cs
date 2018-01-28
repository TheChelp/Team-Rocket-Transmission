using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{

    private Animator animator;
	// Use this for initialization
	void Start ()
	{
	    animator = gameObject.GetComponent<Animator>();
	    StartCoroutine(delayAndOpen());
	}
	

    public IEnumerator delayAndOpen()
    {
        yield return new WaitForSeconds(5);

        if (animator)
        {
            animator.SetBool("door open", true);
        }

        yield return new WaitForSeconds(2);

        gameObject.GetComponent<Collider2D>().enabled = false;

    }

	// Update is called once per frame
	void Update () {
		
	}
}
