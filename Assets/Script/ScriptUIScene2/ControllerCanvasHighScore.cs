using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerCanvasHighScore : MonoBehaviour
{
    public Text DateText;
    public Text ScoreText;

    public GameObject CanvasScene;
    public GameObject CanvasHighScore;
    // Start is called before the first frame update
    void Start()
    {
        CanvasHighScore = gameObject;
        DateText.text = "Date: " + PlayerPrefs.GetString("Date");
        ScoreText.text = "Score: " +PlayerPrefs.GetInt("Score").ToString();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void ClickDelData()
    {
        PlayerPrefs.DeleteAll();
        this.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
    }
    public void exitPanel()
    {
        CanvasHighScore.SetActive(false);
        CanvasScene.SetActive(true);
    }
}
