using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI CakeText = null;
    public TextMeshProUGUI ScoreText = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int countCake = GameObject.FindGameObjectsWithTag("Cake").Length;
        if(GameScore.instance != null && ScoreText != null)
        {
            int score = GameScore.instance.GetScore();
            ScoreText.SetText("Score: " + score);
        }
        if (countCake > 0)
        {
            CakeText.SetText("Cake: " + countCake);
        }
    }
}
