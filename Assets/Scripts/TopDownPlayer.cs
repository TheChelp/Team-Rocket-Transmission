using UnityEngine;
using UnityEngine.SceneManagement;

public class TopDownPlayer : MonoBehaviour {

	public float MoveForce = 10;

	public GameObject LifeIndicator;

	public bool GameOver = false;

	public void PleaseDie()
	{
		GameOver = true;
		Debug.Log ("We died");
	}

	// Use this for initialization
	void Start () {
		if (LifeIndicator)
			LifeIndicator.SendMessage ("RestoreLife");
	}
	
	// Update is called once per frame
	void Update () {

		if (GameOver) {
			if (Input.GetKeyDown (KeyCode.R)) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
				
		} else {

			float horizontal = 0 - Input.GetAxis ("Horizontal");
			float vertical = Input.GetAxis ("Vertical");

			Vector3 horVector = Vector3.left * horizontal * Time.deltaTime * MoveForce;
			Vector3 verVector = Vector3.up * vertical * Time.deltaTime * MoveForce; 
			transform.Translate (horVector);
			transform.Translate (verVector);

	
		}
	}

	public void HitYou()
	{
		Debug.Log ("Player was hit");
		if (LifeIndicator != null)
			LifeIndicator.SendMessage ("LoseLife");
	}

}
