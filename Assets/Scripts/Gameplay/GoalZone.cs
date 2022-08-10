using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZone : MonoBehaviour
{
    [SerializeField] private EventManager.ScoreOrigin scoreOrigin = EventManager.ScoreOrigin.Player;
    
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

        auxBall.Reset();

        EventManager.GoalDetected?.Invoke(scoreOrigin);
    }
}
