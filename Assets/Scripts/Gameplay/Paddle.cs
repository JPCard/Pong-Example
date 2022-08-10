using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Paddle : MonoBehaviour
{
    protected float yDir;
    private Rigidbody2D _rgBody2D;

    [SerializeField] private float throwXDir = 1;
    [SerializeField]
    private float speed = 7;
    [SerializeField]
    private float throwMagnitude = 7;

    private void Awake()
    {
        _rgBody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    

    private void FixedUpdate()
    {
        _rgBody2D.AddForce(new Vector2(0, yDir) * speed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (!col.CompareTag("Ball"))
        {
            return;
        }

        Ball auxBall = col.transform.parent.GetComponent<Ball>();

        if (auxBall == null)
        {
            return;
        }

        Vector2 throwDir;

        if (auxBall.transform.position.y < transform.position.y)
        {
            throwDir = new Vector2(throwXDir, 1);
        }
        else
        {
            throwDir = new Vector2(throwXDir, -1);
        }
        
        auxBall.ThrowBall(throwDir * throwMagnitude);
        
    }
}
