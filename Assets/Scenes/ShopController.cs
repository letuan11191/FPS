using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public Text GoldText;
    int gold;
    // Start is called before the first frame update
    void Start()
    {
        gold = PlayerPrefs.GetInt("Gold");
    }

    // Update is called once per frame
    void Update()
    {
        GoldText.text = PlayerPrefs.GetInt("Gold").ToString();
        
    }
    public void BuyShotgun()
    {
        ControllerScene.audioClip.Play();
        if (PlayerPrefs.GetInt("Gold") >= 100)
        {
            TestPlayerPref.OnSaveBullet("Shotgun", 100);
            TestPlayerPref.OnSave(0, -100, "");
        }
            
    }

    public void BuyUMP40()
    {
        ControllerScene.audioClip.Play();
        if (PlayerPrefs.GetInt("Gold") >= 150)
        {
            TestPlayerPref.OnSaveBullet("UMP40", 100);
            TestPlayerPref.OnSave(0, -150, "");
        }
    }

    public void Grenade()
    {
        ControllerScene.audioClip.Play();
        if (PlayerPrefs.GetInt("Gold") >= 150)
        {
            TestPlayerPref.OnSaveBullet("Grenade", 5);
            TestPlayerPref.OnSave(0, -150, "");
        }
    }

}
