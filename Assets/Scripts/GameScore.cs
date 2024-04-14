using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameScore : MonoBehaviour
{
    public static GameScore instance;

    private const string ScoreKey = "Score";

    private int score = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Update()
    {
        
    }
    public void AddScore(int score)
    {
        this.score += score;
    }

    public int GetScore()
    {
        return score;
    }

}
