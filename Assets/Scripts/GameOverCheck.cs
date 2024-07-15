using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameOverCheck : MonoBehaviour
{
    public InputActionProperty StartButton;
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
        if(StartButton != null && StartButton.action.ReadValue<float>() > 0.9)
        {
            ScoreManager.instance.AddScore(GameScore.instance.GetScore());
            SceneManager.LoadScene("ScoreBoard");
        }
    }
}
