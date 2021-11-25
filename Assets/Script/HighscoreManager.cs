using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighscoreManager : MonoBehaviour
{
   
    public int score;
    

    public Text ScoreText;
    public Text HighscoreText;

    

   

    private void Awake()
    {
        HighscoreText.text = "Highscore: " + GetHighscoore().ToString();
        //ScoreText.text = GetScore().ToString();
    }

  

    public void IncreaseScore()
    {
        score++;
        ScoreText.text = score.ToString();
        PlayerPrefs.SetInt("Score", score);

        if (score > GetHighscoore())
        {
            PlayerPrefs.SetInt("Highscore", score);
            HighscoreText.text = score.ToString();
           


        }
    }

    public int GetHighscoore()
    {
        int i = PlayerPrefs.GetInt("Highscore");
        return i;
    }

    public int GetScore()
    {
        return PlayerPrefs.GetInt("Score");
    }
}
