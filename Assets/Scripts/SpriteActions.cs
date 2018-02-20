using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteActions : MonoBehaviour
{
    public float Offset = 0;
    public GameObject FlashLight;
    public GameObject WavePrefab;
    public bool TutorialTrigger = false;

    private Vector3 _rotationAngles;
    private Animator _animator;
    private SpriteMovement _moveScript;
    

    // Use this for initialization
    void Start()
    {
        _moveScript = gameObject.GetComponent<SpriteMovement>();
        if(_moveScript == null)
            Debug.Log("<color=red> Error: Move script not attached to Player</color>");
        _rotationAngles = new Vector3();
        _animator = gameObject.GetComponent<Animator>();


        if (FlashLight != null)
            _rotationAngles = FlashLight.transform.eulerAngles;


        if (FlashLight == null)
        {
            Debug.Log("Flashlight not found :(");
        }

        if (TutorialTrigger)
        {
            StartCoroutine(TutorialScript());
        }
    }

    public IEnumerator TutorialScript()
    {
        float timer = 9.0f;

        yield return _moveScript.MoveFor(SpriteMovement.Direction.RIGHT, 9.0f);
        yield return new WaitForSeconds(4);
        yield return _moveScript.MoveFor(SpriteMovement.Direction.LEFT, 4.1f);
        yield return _moveScript.MoveFor(SpriteMovement.Direction.UP, 0.5f);
    }

    public IEnumerator ToDoor()
    {
        //        left = true;
        //        yield return new WaitForSeconds(4.8f);
        //        left = false;
        //        up = true;
        //        yield return new WaitForSeconds(0.5f);
        //        up = false;
        //        yield return new WaitForSeconds(1.0f);
        //        SceneManager.LoadScene("Scenes/Level2");
        return null;
    }

    void Update()
    {
        if (FlashLight != null)
        {
            Vector3 d = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;

            Vector2 dist = new Vector2(d.x, d.y);
            dist.Normalize();
            float angle = Mathf.Rad2Deg * -Mathf.Atan2(dist.y, dist.x);
            FlashLight.transform.eulerAngles = new Vector3(angle, 90, 0);

            if (Input.GetMouseButtonDown(0))
            {
                GameObject wave = Instantiate(WavePrefab);
                wave.name = "Wave";
                wave.GetComponent<WaveActions>().Velocity = new Vector3(dist.x, dist.y, 0);
                wave.GetComponent<WaveActions>().transform.eulerAngles = new Vector3(0, 0, -angle);
                wave.GetComponent<WaveActions>().transform.position +=
                    new Vector3(gameObject.transform.position.x + 1.5f * dist.x,
                        gameObject.transform.position.y + 1.5f * dist.y, 0);
                wave.GetComponent<WaveActions>().transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            }
        }

        
	    if (_animator != null)
	    {
	        _animator.SetFloat("velocityX", _moveScript.GetVelX());
            _animator.SetFloat("velocityY", _moveScript.GetVelY());
	    }
        
    }
}