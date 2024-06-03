using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.ComponentModel;

public class UIBestScore : MonoBehaviour
{

    //Script to handle display of High Scores
    //Attached to UI - Per original Script
    public TextMeshProUGUI bestScoreText;
    // Drag Text UI into this in the Inspector

    void Start()
    {
        //LOAD HIGH SCORE
        MainManager.Instance.LoadHighScore();

        Debug.Log("High Score is " + MainManager.Instance.highScore);
        //Above Option - Testing

        //DISPLAY HIGH SCORE AND PLAYER
        if (MainManager.Instance != null)
        {
            if(MainManager.Instance.highScore != 0)
            {
                DisplayHighScore();
            }
            else
            {
                DisplayName();
            }
        }
        else
        {
            bestScoreText.text = "Hello, set a high score!";
        }

        //Extra Display Code Removed

    }

    void DisplayHighScore()
    {
        bestScoreText.tag = MainManager.Instance.playerName + ", can you beat the High Score " + MainManager.Instance.highScore + " by "+ MainManager.Instance.highScoreName + "?";
    }

    void DisplayName()
    {
        bestScoreText.text = MainManager.Instance.playerName + ", set a High Score!";
    }
}
