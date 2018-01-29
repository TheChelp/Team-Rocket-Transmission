using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class VideoTransition : MonoBehaviour
{
    public  VideoPlayer VideoPlayer;
	// Use this for initialization
	void Start ()
	{
	    VideoPlayer.loopPointReached += EndReached;

	}

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Scenes/Title Scene");
    }
}
