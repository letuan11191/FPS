using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class TestPlayerPref
{
    public static int Score;
    public static int Gold;
    public static string dateScore = "";

    static int bulletShotgunPP;
    static int bulletUMP40PP;
    static int grenadePP;
    // Start is called before the first frame update


    // Update is called once per frame


    public static void OnSave(int score, int gold, string dateScore)
    {
        Gold = PlayerPrefs.GetInt("Gold");
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

    public static void OnSaveBullet(string name, int pp)
    {
        if (name == "Shotgun")
        {
            bulletShotgunPP += pp;
            PlayerPrefs.SetInt("ShotgunPP", bulletShotgunPP);
        }
            
        if (name == "UMP40")
        {
            bulletUMP40PP += pp;
            PlayerPrefs.SetInt("UMP40PP", bulletUMP40PP);
        }
            
        if (name == "Grenade")
        {
            grenadePP += pp;
            PlayerPrefs.SetInt("GrenadePP", grenadePP);
        }
        PlayerPrefs.Save();
            
    }

    
}
