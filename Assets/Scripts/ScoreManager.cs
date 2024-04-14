using UnityEngine;
using System;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private const string ScoreKey = "ScoreBoard";
    private const int MaxScoresToKeep = 10;

    [System.Serializable]
    public class ScoreEntry
    {
        public int score;
        public DateTime timestamp;

        public ScoreEntry(int score, DateTime timestamp)
        {
            this.score = score;
            this.timestamp = timestamp;
        }
    }

    private List<ScoreEntry> topScores = new();

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

        LoadScores();
    }

    public void AddScore(int score)
    {
        ScoreEntry newEntry = new ScoreEntry(score, DateTime.Now);
        topScores.Add(newEntry);
        topScores.Sort((a, b) => b.score.CompareTo(a.score)); // Sort in descending order
        if (topScores.Count > MaxScoresToKeep)
        {
            topScores.RemoveAt(topScores.Count - 1); // Remove the lowest score if over the limit
        }
        SaveScores();
    }

    public List<ScoreEntry> GetTopScores()
    {
        return topScores;
    }

    private void LoadScores()
    {
        string json = PlayerPrefs.GetString(ScoreKey);
        if (!string.IsNullOrEmpty(json))
        {
            topScores = JsonUtility.FromJson<List<ScoreEntry>>(json);
        }
    }

    private void SaveScores()
    {
        string json = JsonUtility.ToJson(topScores);
        PlayerPrefs.SetString(ScoreKey, json);
        PlayerPrefs.Save();
    }
}
