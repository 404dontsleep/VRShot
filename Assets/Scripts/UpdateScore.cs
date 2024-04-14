using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI scoreList;
    private ScoreManager scoreManager;
    void Start()
    {
        scoreManager = ScoreManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        var text = "";
        List<ScoreManager.ScoreEntry> list = scoreManager.GetTopScores();
        for (int i = 0; i < list.Count; i++)
        {
            ScoreManager.ScoreEntry score = list[i];
            if (score != null)
            {
                text += $"{i + 1}\t${score.timestamp}\t{score.score}\n";
            }
        }
        scoreList.text = text;
    }
}
