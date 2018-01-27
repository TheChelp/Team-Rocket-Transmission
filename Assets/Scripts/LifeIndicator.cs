using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeIndicator : MonoBehaviour {

	public int LifeLevel = 6;
	private int LastShownLevel = -1;

	public List<GameObject> TheImages = new List<GameObject> ();

	private GameObject ThePlayer=null;


	void ShowCurrentState()
	{
		if (LastShownLevel != 0 && LifeLevel == 0) {
			if (ThePlayer != null)
				ThePlayer.SendMessage ("PleaseDie");
		}
		
		if (LifeLevel >= 0 && LifeLevel < NumberOfImages) {
			foreach (GameObject imageObj in TheImages) {
				imageObj.SetActive (false);
			}
			TheImages [LifeLevel].SetActive (true);
		}
			
		LastShownLevel = LifeLevel;
	}

	public void SetValue(int newValue)
	{
		newValue = newValue % NumberOfImages;
		LifeLevel = newValue;
		ShowCurrentState ();
	}

	public void LoseLife()
	{
		Debug.Log ("Losing life");
		if (LifeLevel > 0)
			LifeLevel--;
		ShowCurrentState ();
	}

	public void GainLife()
	{
		if (LifeLevel < NumberOfImages-1)
			LifeLevel++;
		ShowCurrentState ();
	}

	public void RestoreLife()
	{
		NumberOfImages = TheImages.Count;
		LifeLevel = NumberOfImages-1;
		ShowCurrentState ();
	}

	private int NumberOfImages;

	// Use this for initialization
	void Start () {
		ThePlayer = GameObject.FindGameObjectWithTag ("Player");

		NumberOfImages = TheImages.Count;
		ShowCurrentState ();
	}
	
	// Update is called once per frame
	void Update () {
		if (LifeLevel != LastShownLevel) {
			ShowCurrentState ();
		}

	}
}
