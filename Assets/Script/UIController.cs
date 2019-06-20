using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public GameObject CanvasPause;
    public GameObject CanvasGame;
    public GameObject ContinueBtn;
    public Text TextGame;
    public Text TextScore;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void clickContinue()
    {
        ContinueBtn.SetActive(false);
        Time.timeScale = 1;
        Game_Controller.CanvasEndGame.SetActive(false);
        CanvasGame.SetActive(true);
    }
    public void clickRestart()
    {
        SceneManager.LoadScene("TestSave");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void clickSetting()
    {
        Time.timeScale = 0;
        Game_Controller.CanvasEndGame.SetActive(true);
        ContinueBtn.SetActive(true);
        TextGame.text = "Pause";
        TextScore.text = "";
        CanvasGame.SetActive(false);
        
    }
}
