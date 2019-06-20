using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class TestPlayerPref
{
    public static int Score = 0;
    public static int Gold = 0;
    public static string dateScore = "";
    // Start is called before the first frame update


    // Update is called once per frame


    public static void OnSave(int score, int gold, string dateScore)
    {
        if(score > Score)
        {
            Score = score;
            PlayerPrefs.SetInt("Score", Score);
            PlayerPrefs.SetString("Date", dateScore);
        }            
        Gold += gold;
        PlayerPrefs.SetInt("Gold", Gold);        
        PlayerPrefs.Save();
    }

    
}
