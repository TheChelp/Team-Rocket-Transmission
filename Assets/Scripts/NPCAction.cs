using UnityEngine;
using System.Collections;

public class NPCAction : MonoBehaviour
{
    private Animator _animator;
    private float _dx, _dy;
    public float Speed;
    public GameObject Player;
    // Use this for initialization
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        StartCoroutine(tutScript());
    }

    public IEnumerator tutScript()
    {
        right = true;
        yield return new WaitForSeconds(9);
        right = false;
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


    public bool right, left, down, up;
    // Update is called once per frame
    void Update()
    {
        if (up)
        {
            _dy++;
        }
        if (down)
        {
            _dy--;
        }
        if (left)
        {
            _dx--;
        }
        if (right)
        {
            _dx++;
        }

        float velocityX = _dx * Speed;
        float velocityY = _dy * Speed;

        if (_animator != null)
        {
            _animator.SetFloat("velocityX", velocityX);
            _animator.SetFloat("velocityY", velocityY);
        }

        gameObject.transform.position += new Vector3(velocityX, velocityY, 0);
        _dx = 0;
        _dy = 0;

    }

}
