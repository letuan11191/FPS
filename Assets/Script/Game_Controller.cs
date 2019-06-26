
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class Game_Controller : MonoBehaviour
{
    public GameObject BossHealth;

    public static GameObject Gun;
    public GameObject Grenade;
    

    public Text Timetxt;
    public Text Scoretxt;
    public Text Bullettxt;
    public GameObject ContinueBtn;
    public static int TimeGame;
    public static int Score;

    int OldTimeGame;

    public static int speed;

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
    public static int numGrenade;
    public Text numGrenadeText;
    public Button BtnGrenade;

    public static int bulletShotGun;
    public static int bulletUMP40;

    float x = 1;
    bool bossBool;
    void Awake()
    {
        bossBool = false;
        bulletShotGun = 50 + PlayerPrefs.GetInt("ShotgunPP");
        bulletUMP40 = 50 + PlayerPrefs.GetInt("UMP40PP");
        Grenade.SetActive(false);
        numGrenade = 3 + PlayerPrefs.GetInt("GrenadePP");
        //sBullet = 200;
        Time.timeScale = 0;
        Score = 0;
        TimeGame = 200;
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
        Gun = GameObject.FindGameObjectWithTag("Weapon");
        CanvasMatMau = GameObject.Find("Canvas_MatMau");
        CanvasEndGame = GameObject.Find("Canvas_EndGame");
        CanvasMatMau.SetActive(false);
        CanvasEndGame.SetActive(false);
        ContinueBtn.SetActive(false);
        BossHealth.SetActive(false);
    }
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
    }
    int numBoss = 0;

    void Update()
    {
        if(!bossBool)
        {
            DemNguocThoiGian();
        }
        if(Gun)
        {
            if (Gun.transform.name == "Pistol")
            {
                Bullettxt.text = "Bullet: ∞";
            }
            else if (Gun.transform.name == "Shotgun")
            {
                Bullettxt.text = "Bullet: " + bulletShotGun;
            }
            else if (Gun.transform.name == "UMP40")
            {
                Bullettxt.text = "Bullet: " + bulletUMP40;
            }
        }
        else
            Bullettxt.text = "Bullet: ∞";


        Timetxt.text = "Time: " +TimeGame.ToString();
        Scoretxt.text = "Score: "+Score.ToString();
        numGrenadeText.text = numGrenade.ToString();


        if(numGrenade == 0)
        {
            BtnGrenade.enabled = false;
        }
        else if(numGrenade > 0)
        {
            BtnGrenade.enabled = true;
        }

        //xu ly end game
        if (TimeGame == 0 && !bossBool)
        {
            EndGame(true);
        }
        else if(Health.transform.localPosition.x <= -705 && TimeGame!= 0)
        {
            EndGame(false);
        }
        else if(bossBool && BossHealth.transform.localPosition.x <= -705)
        {
            EndGame(true);
        }
        //
        if(Score >= 500 && numBoss == 0)
        {
            x = 0;
            GameObject boss = Instantiate(Resources.Load<GameObject>("Boss/Demon Blade Lord"), new Vector3(0,0,25), Quaternion.identity);
            boss.transform.localRotation = new Quaternion(0, 180, 0, 0);
            BossHealth.SetActive(true);
            bossBool = true;
            numBoss++;
            Timetxt.text = "";
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
        TestPlayerPref.OnSaveBullet("Shotgun", 0);
        TestPlayerPref.OnSaveBullet("UMP40", 0);
        TestPlayerPref.OnSaveBullet("Grenade", 0);



    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Ground.transform.position += Vector3.back * speed * Time.deltaTime * x;
        if (Time.time - oldTime > 10)
        {
            oldTime = Time.time;
            speed++;
        }
        if(!bossBool)
        {
            CreateEnemy();
        }        
        CreateBullet();
        CreateHealth();
        CreateGrenade();
        //CreateTimeICe();
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
            int rd = Random.Range(0, 2);
            GameObject bulletPlus = Resources.LoadAll<GameObject>("BulletGun")[rd];
            Instantiate(bulletPlus, new Vector3(rdx, 8, rdz), Quaternion.identity);
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

    public GameObject GrenadePlus;
    public static int numGrenadePlus = 0;
    float timeCreateGrenade = 0;

    void CreateGrenade()
    {
        float rdx = Random.Range(-7, 7);
        float rdz = Random.Range(7, 9);
        if (numGrenadePlus < 3 && Time.time - timeCreateGrenade > 8)
        {
            Instantiate(GrenadePlus, new Vector3(rdx, 8, rdz), Quaternion.identity);
            numGrenadePlus++;
            timeCreateGrenade = Time.time;
        }
    }

    public GameObject timeIce;
    public static int numTimeIce = 0;
    float timeCreateTimeIce = 0;

    void CreateTimeICe()
    {
        float rdx = Random.Range(-7, 7);
        float rdz = Random.Range(7, 9);
        if (numTimeIce < 3 && Time.time - timeCreateTimeIce > 2)
        {
            Debug.Log("Create TimeIce");
            Instantiate(timeIce, new Vector3(rdx, 8, rdz), Quaternion.identity);
            numTimeIce++;
            timeCreateTimeIce = Time.time;
        }
    }
}
