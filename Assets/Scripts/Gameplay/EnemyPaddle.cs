using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaddle : Paddle
{
    [SerializeField] private Transform ballTransform;
    [SerializeField] private float maxSeekDistance = 4f;
    
    
    // Update is called once per frame
    void Update()
    {
        var xDistanceToBall = Mathf.Abs(transform.position.x - ballTransform.position.x); 
        if (xDistanceToBall > maxSeekDistance)
        {
            yDir = 0;
        }
        else
        {
            if (transform.position.y < ballTransform.position.y)
            {
                yDir = 1;
            }
            else
            {
                yDir = -1;
            }
        }
    }
}
