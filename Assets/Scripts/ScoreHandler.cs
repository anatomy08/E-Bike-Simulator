using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] float scoreMultiplier; // multiplier so we can add the score how much per seconds

    public const string HighScoreKey = "HighScore"; // we type this instead just putting String so we wont get typo
                                                // like in in invoke(nameof(nameofmethod))
    // conts means it cannot be change

    float score; // the player score

    void Update()
    {
        score += Time.deltaTime * scoreMultiplier; // so in every seconds score is add to 1// pay attention to +=



        scoreText.text = Mathf.FloorToInt(score).ToString(); // since our score is float and our ui is string we need to convert it to string.
                                                        // Mathf.floortoint means make the float to integer without decimal.
    }

     void OnDestroy()  // this method is from unity itself for destroying game object. and responsible for maintaining the highscore
     {
        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0); // get the current high score 
        // if we dont find greater than 0 we stay zero

        if(score > currentHighScore) // if score is greaterthan currenthighscore
        {
            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(score));  // we set a new one

            // PlayerPrefs is a class that stores player refernce it can return int, string, float values
            // mathf floor to int to get rid of decimal scores
            
        }
    }
}
