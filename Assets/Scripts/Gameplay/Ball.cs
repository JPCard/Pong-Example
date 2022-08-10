using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float throwSpeed;

    private Rigidbody2D _rgBody2D;


    public void Reset()
    {
        transform.position = Vector2.zero;
        _rgBody2D.velocity = Vector2.zero;
        StartCoroutine(InitialBallThrow());
    }
    
    private void Awake()
    {
        _rgBody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private IEnumerator InitialBallThrow()
    {
        yield return new WaitForSecondsRealtime(2f);
        
        float xDir = Random.Range(0.5f, 1);
        if (Random.value < 0.5f)
        {
            xDir = -xDir;
        }

        float yDir;
        if (Random.value < 0.5f)
        {
            yDir = 1;
        }
        else
        {
            yDir = -1;
        }


        ThrowBall(new Vector2(xDir, yDir).normalized * throwSpeed);
    }

    public void ThrowBall(Vector2 force)
    {
        _rgBody2D.velocity = Vector2.zero;
        _rgBody2D.AddForce(force);
    }

    void Start()
    {
        StartCoroutine(InitialBallThrow());
    }

}
