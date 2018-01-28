using UnityEngine;
using System.Collections;

public class NPCAction : MonoBehaviour
{
    private Animator _animator;
    private float _dx, _dy;
    public float Speed;

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
    }

    public IEnumerator FallOver()
    {
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
