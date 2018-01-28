using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

	public GameObject ThePlayer = null;

	public float MoveSpeed = 3f;
	public float MaxDistance = 15f;

	public Vector3 _offset;         //Private variable to store the offset distance between the player and camera

	// Use this for initialization
	void Start () 
	{
	    if (ThePlayer != null)
	    {
	        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
	        _offset.z = transform.position.z - ThePlayer.transform.position.z;
	    }
	}

	// LateUpdate is called after Update each frame
	void LateUpdate ()
	{
		float dist = Vector3.Distance (transform.position, ThePlayer.transform.position + _offset);
		if (dist > MaxDistance)
        {
			// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
			transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position + _offset, MoveSpeed * Time.deltaTime);
		}
	}
}
