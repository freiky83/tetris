using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    private int m_score = 2;

    public int Score
    {
        get => m_score;
    }

    protected override string GetSingletonName()
    {
        return "ScoreManager";
    }
}
