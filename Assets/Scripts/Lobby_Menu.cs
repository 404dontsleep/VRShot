using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Lobby");
    }
}
