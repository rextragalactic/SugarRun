using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighscoreManager : MonoBehaviour
{
   
    

    public Text ScoreText;
    public Text HighscoreText;

    
    
   

    private void Awake()
    {
        HighscoreText.text = "Highscore: " + GetHighscoore().ToString();
        ScoreText.text = Highscore.Score.ToString();
        

    }



    public void IncreaseScore()
    {
        Highscore.Score++;
        ScoreText.text = Highscore.Score.ToString();
        PlayerPrefs.SetInt("Score", Highscore.Score);

        if (Highscore.Score > GetHighscoore())
        {
            PlayerPrefs.SetInt("Highscore", Highscore.Score);
            HighscoreText.text = Highscore.Score.ToString();
           


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
