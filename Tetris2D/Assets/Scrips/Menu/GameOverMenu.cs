using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public static bool gameOver = false;
    public GameObject gameOverMenu;
    public GameObject Points;

    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI endPoint;

    // Start is called before the first frame update
    void Start()
    {
        highscoreText.text = "Highscore : " + PlayerPrefs.GetInt("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            gameOverMenu.SetActive(true);
            Points.SetActive(false);
            endPoint.text = PointUpdate.point.ToString();
        }
        else
        {
            gameOverMenu.SetActive(false);
            Points.SetActive(true);
        }
    }


    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
