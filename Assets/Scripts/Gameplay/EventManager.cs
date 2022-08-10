using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public enum ScoreOrigin
    {
        Player,
        Enemy
    }
    
    public static Action<ScoreOrigin> GoalDetected;
    
    public static Action<int, int> ScoreChanged;
}
