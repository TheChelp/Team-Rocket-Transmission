using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalResponse : MonoBehaviour
{

    public GameObject Controller;
    public int index;

    public GameObject Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D other)
    { 
        Player.SendMessage("PausePlayer");
        Controller.transform.GetChild(0).gameObject.SetActive(false);
        Controller.transform.GetChild(index).gameObject.SetActive(false);
        
    }
}
