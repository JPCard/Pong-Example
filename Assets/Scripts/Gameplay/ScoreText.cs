using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private EventManager.ScoreOrigin scoreOrigin = EventManager.ScoreOrigin.Player;
    
    private void Awake()
    {
        EventManager.ScoreChanged += OnScoreChanged;
    }

    private void OnDestroy()
    {
        EventManager.ScoreChanged -= OnScoreChanged;
    }


    private void OnScoreChanged(int playerScore, int enemyScore)
    {
        switch (scoreOrigin)
        {
            case EventManager.ScoreOrigin.Player:
                _text.text = playerScore.ToString();
                break;
            case EventManager.ScoreOrigin.Enemy:
                _text.text = enemyScore.ToString();
                break;
        }
    }
    
}
