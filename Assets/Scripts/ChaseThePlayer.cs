using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseThePlayer : MonoBehaviour {

	GameObject thePlayer = null;
	public float SluggishTimeInterval = 0.5f;
	public float MovementSpeed = 7;
	public float AttackRecoveryTime = 0.5f;
	float alertnessTimer = 0;
	float attackRecoveryTimer = 0;
	public Vector3 WhereToGo = new Vector3 ();

	// Use this for initialization
	void Start () {
		thePlayer = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		attackRecoveryTimer -= Time.deltaTime;
		alertnessTimer += Time.deltaTime;
		if (alertnessTimer > SluggishTimeInterval) {
			if (thePlayer != null) {
				WhereToGo = thePlayer.transform.position;
			}
			alertnessTimer = 0f;
		}

		Vector3 newPosition = Vector3.MoveTowards (transform.position, WhereToGo, MovementSpeed * Time.deltaTime);
		transform.position = newPosition;
		transform.LookAt (WhereToGo);
	}


	void OnCollisionEnter(Collision collision)
	{
		if (attackRecoveryTimer <= 0) {
			Debug.Log ("Hit Something");
			if (collision.collider.tag == "Player") {
				collision.collider.gameObject.SendMessage ("HitYou");
				attackRecoveryTimer = AttackRecoveryTime;
			}
		}
	}

}
