using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Playgame : MonoBehaviour
{
    [SerializeField] TMP_Text highScoreText; // get reference from TMP_text
    [SerializeField] TMP_Text energyText;
    [SerializeField] Button playButton;
    [SerializeField] AndroidNotificationHandler androidNotificationHandler;
    [SerializeField] iOSNotificationHandler iosNotificationHandler;
    [SerializeField] int maxEnergy;
    [SerializeField] int energyRechargeDuration;
    int energy;

    const string EnergyKey = "Energy";
    const string EnergyReadyKey = "EnergyReady";

    void Start()
    {
        OnApplicationFocus(true);
    }

    void  OnApplicationFocus(bool hasFocus) 

    {

       if(!hasFocus) {return;}

       CancelInvoke();

       int highScore = PlayerPrefs.GetInt(ScoreHandler.HighScoreKey, 0);
        
        highScoreText.text = $"High Score: {highScore}";

        energy = PlayerPrefs.GetInt(EnergyKey, maxEnergy); // where maxenergy is the default 

        if(energy == 0) 
        {
            string energyReadyString = PlayerPrefs.GetString(EnergyReadyKey, string.Empty);

            if(energyReadyString == string.Empty ) {return;}

            DateTime energyReady = DateTime.Parse(energyReadyString); // Datetime current Date time in realworld

            if(DateTime.Now >energyReady) 
            {
                energy = maxEnergy;
                PlayerPrefs.SetInt(EnergyKey, energy);
            }
            else 
            {
                playButton.interactable = false;
                Invoke(nameof(EnergyRecharge), (energyReady - DateTime.Now).Seconds);
            }
            
        }

        energyText.text = $"Play ({energy})";
    }

    void EnergyRecharge()
    {
        playButton.interactable = true;
        energy = maxEnergy;
        PlayerPrefs.SetInt(EnergyKey, energy);
        energyText.text = $"Play ({energy})";
    }
    public void PlayGame()
    {
        if  ( energy < 1) {return;} // if no energy we cannot play.

        energy--; // we play we decrease energy

        PlayerPrefs.SetInt(EnergyKey, energy); // save our new energy value after consuming

        if(energy == 0) // check to see if we have any energy left by now. if not
        {
            DateTime energyReady = DateTime.Now.AddMinutes(energyRechargeDuration); // when the energy will be restore and Datetime.
            PlayerPrefs.SetString(EnergyReadyKey, energyReady.ToString()); // we save it to playerPrefs
#if UNITY_ANDROID
            androidNotificationHandler.ScheduleNotification(energyReady);
#elif UNITY_IOS
            iosNotificationHandler.ScheduleNotifaction(energyRechargeDuration);
#endif
        }


        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
