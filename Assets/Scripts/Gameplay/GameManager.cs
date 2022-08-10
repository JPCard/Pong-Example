using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _playerScore = 0;
    private int _enemyScore = 0;


    private void Awake()
    {
        EventManager.GoalDetected += OnGoalDetected;
    }

    private void OnDestroy()
    {
        EventManager.GoalDetected -= OnGoalDetected;
    }

    private void OnGoalDetected(EventManager.ScoreOrigin scoreOrigin)
    {
        switch (scoreOrigin)
        {
            case EventManager.ScoreOrigin.Player:
                _playerScore++;
                break;
            case EventManager.ScoreOrigin.Enemy:
                _enemyScore++;
                break;
        }


        EventManager.ScoreChanged(_playerScore, _enemyScore);
    }
    
    
}
