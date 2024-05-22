using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameScore : MonoBehaviour
{
    public static GameScore instance;

    private const string ScoreKey = "Score";
    public AudioSource scoreAudio = null;

    private int score = 0;
    private void Awake()
    {
        scoreAudio = GetComponent<AudioSource>();
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
        if(scoreAudio != null)
        {
            scoreAudio.Play();
        }
        this.score += score;
    }
    public void ResetScore()
    {
        this.score = 0;
    }
    public int GetScore()
    {
        return score;
    }

}
