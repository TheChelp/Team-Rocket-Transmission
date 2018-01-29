using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Utils : MonoBehaviour
{
    public int mode;
    public Button btn;
   
    // Use this for initialization
    void Start ()
    {
        if(mode == 1)
            btn.onClick.AddListener(LoadTutorial);
        else
            btn.onClick.AddListener(DoExitGame);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DoExitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }

    public void LoadTutorial()
    {
        Debug.Log("LOADING TUTORIAL");
        SceneManager.LoadScene("Scenes/Tutorial");
    }
}
