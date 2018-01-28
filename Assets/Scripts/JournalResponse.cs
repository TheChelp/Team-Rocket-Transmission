using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalResponse : MonoBehaviour
{

    public GameObject Controller;

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
        Controller.transform.GetChild(0).gameObject.SetActive(true);
        Controller.transform.GetChild(1).gameObject.SetActive(false);
        
    }
}
