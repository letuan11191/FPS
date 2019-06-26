using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerScene : MonoBehaviour
{
    public GameObject CanvasScene;
    public GameObject CanvasHighScore;
    public GameObject CanvasShop;
    public GameObject AudioObj;
    public static AudioSource audioClip;
    // Start is called before the first frame update
    void Start()
    {
        audioClip = AudioObj.GetComponent<AudioSource>();
        CanvasScene = gameObject;
        CanvasScene.SetActive(true);
        CanvasHighScore.SetActive(false);
        CanvasShop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickStartGame()
    {
        audioClip.Play();
        SceneManager.LoadScene("Game");
    }
    public void CLickHighScore ()
    {
        audioClip.Play();
        CanvasScene.SetActive(false);
        CanvasHighScore.SetActive(true);
    }
    public void ClickShop()
    {
        audioClip.Play();
        CanvasScene.SetActive(false);
        CanvasShop.SetActive(true);
    }

    public void exitPanel()
    {
        audioClip.Play();
        CanvasShop.SetActive(false);
        CanvasHighScore.SetActive(false);
        CanvasScene.SetActive(true);
    }

    public void Exit()
    {
        audioClip.Play();
        Application.Quit();
    }
}
