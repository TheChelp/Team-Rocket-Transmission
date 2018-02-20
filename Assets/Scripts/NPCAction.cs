using UnityEngine;
using System.Collections;

public class NPCAction : MonoBehaviour
{
    private Animator _animator;
    public GameObject Player;

    private SpriteMovement _moveScript;
    // Use this for initialization
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _moveScript = gameObject.GetComponent<SpriteMovement>();
        if (_moveScript == null)
            Debug.Log("<color=red> Error: Move script not attached to NPC</color>");

        StartCoroutine(tutScript());
    }

    public IEnumerator tutScript()
    {
        yield return _moveScript.MoveFor(SpriteMovement.Direction.RIGHT, 9.0f);
        yield return StartCoroutine(FallOver());
        yield return StartCoroutine(Bleed());
        yield return StartCoroutine(Fade());

        yield return new WaitForSeconds(2);
        yield return StartCoroutine(Player.GetComponent<SpriteActions>().ToDoor());



    }

    public IEnumerator Bleed()
    {
        Color color = gameObject.GetComponent<SpriteRenderer>().color;

        for (float i = 1; i > 0; i -= 0.05f)
        {
            color.g = i;
            color.b = i;
            gameObject.GetComponent<SpriteRenderer>().color = color;
            yield return null;
        }
        yield return null;
    }


    public IEnumerator Fade()
    {
        Color color = gameObject.GetComponent<SpriteRenderer>().color;

        for (float i = 1; i > 0; i -= 0.01f)
        {
            color.a = i;
            gameObject.GetComponent<SpriteRenderer>().color = color;
            yield return null;
        }
        yield return null;
    }

    public IEnumerator FallOver()
    {
        Vector3 angles = gameObject.transform.eulerAngles;
        
        for (int i = 0; i < 90; i++)
        {
            angles.z += 10;
            gameObject.transform.eulerAngles = angles;
            yield return null;
        }
        yield return null;
    }


    // Update is called once per frame
    void Update()
    {
        if (_animator != null)
        {
            _animator.SetFloat("velocityX", _moveScript.GetVelX());
            _animator.SetFloat("velocityY", _moveScript.GetVelY());
        }
    }

}
