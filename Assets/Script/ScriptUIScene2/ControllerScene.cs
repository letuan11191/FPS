using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerScene : MonoBehaviour
{
    public GameObject CanvasScene;
    public GameObject CanvasHighScore;
    // Start is called before the first frame update
    void Start()
    {
        CanvasScene = gameObject;
        CanvasScene.SetActive(true);
        CanvasHighScore.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickStartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void CLickHighScore ()
    {
        CanvasScene.SetActive(false);
        CanvasHighScore.SetActive(true);
    }
    public void ClickShop()
    {
        
    }

    
    public void Exit()
    {
        Application.Quit();
    }
}
