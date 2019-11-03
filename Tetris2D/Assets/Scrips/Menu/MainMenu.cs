using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;

    // Start is called before the first frame update
    void Start()
    {
        highscoreText.text = "Highscore : " + PlayerPrefs.GetInt("Highscore");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
        GameOverMenu.gameOver = false;
        PauseMenu.gamePause = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
