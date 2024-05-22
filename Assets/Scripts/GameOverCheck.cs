using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Cake") == null)
        {
            ScoreManager.instance.AddScore(GameScore.instance.GetScore());
            SceneManager.LoadScene("ScoreBoard");
        }
    }
}
