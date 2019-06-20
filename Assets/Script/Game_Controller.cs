
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class Game_Controller : MonoBehaviour
{
    public Text Timetxt;
    public Text Scoretxt;
    public Text Bullettxt;
    public GameObject ContinueBtn;
    public static int TimeGame;
    public static int Score;

    int OldTimeGame;

    public static int speed;
    public static int Bullet;

    static float oldTime;
    static float timeCreateEnemy;
    public static GameObject CanvasMatMau;
    public static GameObject CanvasEndGame;
    public GameObject CanvasGame;

    public GameObject Ground;
    public GameObject Health;

    public GameObject Player;

    List<GameObject> lstEnemy;

    public static int numEnemy;

    void Awake()
    {
        Debug.Log("Awake Game Controller");
        Bullet = 200;
        Time.timeScale = 0;
        Score = 0;
        TimeGame = 60;
        OldTimeGame = 0;
        lstEnemy = new List<GameObject>();
        foreach (GameObject a in Resources.LoadAll<GameObject>("Prefabs/"))
        {
            lstEnemy.Add(a);
        }
        timeCreateEnemy = 0;
        numEnemy = 0;
        speed = 1;
        oldTime = 0;
        CanvasGame.SetActive(true);
        CanvasMatMau = GameObject.Find("Canvas_MatMau");
        CanvasEndGame = GameObject.Find("Canvas_EndGame");
        CanvasMatMau.SetActive(false);
        CanvasEndGame.SetActive(false);
        ContinueBtn.SetActive(false);
    }
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {

        DemNguocThoiGian();
        Bullettxt.text = "Bullet: " + Bullet.ToString(); 
        Timetxt.text = "Time: " +TimeGame.ToString();
        Scoretxt.text = "Score: "+Score.ToString();
        if(TimeGame == 0)
        {
            EndGame(true);
        }
        else if(Health.transform.localPosition.x <= -705 && TimeGame!= 0)
        {
            EndGame(false);
        }
    }
    void DemNguocThoiGian()
    {
        if(Time.time - oldTime > 1)
        {
            TimeGame--;
            oldTime = Time.time;
        }
    }

    public Text EndGameText;
    public Text EndGameScore;
    void EndGame(bool KQ)
    {
        CanvasEndGame.SetActive(true);
        if (KQ)
            EndGameText.text = "You Win";
        else
            EndGameText.text = "You Lose";
        EndGameScore.text = "You Score: " + Score.ToString();
        
        Time.timeScale = 0;
        CanvasGame.SetActive(false);        
        TestPlayerPref.OnSave(Score, Score, System.DateTime.Now.ToString());
        
        
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Ground.transform.position += Vector3.back * speed * Time.deltaTime;
        if (Time.time - oldTime > 10)
        {
            oldTime = Time.time;
            speed++;
        }
        CreateEnemy();
        CreateBullet();
        CreateHealth();
    }
    void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Enemy")
        {
            Destroy(Other.gameObject);
            numEnemy--;
        }
    }

    void CreateEnemy()
    {
        int randomX = Random.Range(-4, 4);
        float distanctPlayer = Player.transform.position.z;
        float vectorZ = distanctPlayer + 40;
        int Rd = Random.Range(0, lstEnemy.Count);
        if (numEnemy < 5 && Time.time - timeCreateEnemy > 3)
        {
            Instantiate(lstEnemy[Rd], new Vector3(randomX, 0, vectorZ), new Quaternion(0,180,0,0));
            numEnemy++;
            timeCreateEnemy = Time.time;
        }
    }
    public GameObject BulletPlus;
    public static int numBulletPlus = 0;
    static float timeCreateItem = 0;
    void CreateBullet()
    {
        float rdx = Random.Range(-7,7);
        float rdz = Random.Range(7,9);
        if(numBulletPlus < 3 && Time.time - timeCreateItem > 5)
        {
            Instantiate(BulletPlus, new Vector3(rdx, 8, rdz), Quaternion.identity);
            numBulletPlus++;
            timeCreateItem = Time.time;
        }
    }

    public GameObject HealthPlus;
    public static int numHealth = 0;
    float timeCreateHealth = 0;

    void CreateHealth()
    {
        float rdx = Random.Range(-7, 7);
        float rdz = Random.Range(7, 9);
        if (numHealth < 3 && Time.time - timeCreateHealth > 8)
        {
            Instantiate(HealthPlus, new Vector3(rdx, 8, rdz), Quaternion.identity);
            numHealth++;
            timeCreateHealth = Time.time;
        }
    }
}
