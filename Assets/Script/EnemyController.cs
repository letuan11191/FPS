using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject game_Controller;
    public int BloodEnemy;
    public bool run;
    bool die;
    float speedEnemy;
    float powerEnemy;

    // Use this for initialization
    void Start()
    {
        game_Controller = GameObject.Find("Game_Controller");
        run = true;
        die = true;
        switch (this.name)
        {
            case "Lancer(Clone)": BloodEnemy = 6; speedEnemy = 2f; powerEnemy = 40; break;
            case "Lancer": BloodEnemy = 6; speedEnemy = 2f; powerEnemy = 40; break;
            case "EvilArmor_B_SKEL(Clone)": BloodEnemy = 8; speedEnemy = 1.5f; powerEnemy = 50; break;
            case "EvilArmor": BloodEnemy = 8; speedEnemy = 1.5f; powerEnemy = 50; break;
            case "LesserImp(Clone)": BloodEnemy = 1; speedEnemy = 3.5f; powerEnemy = 20; break;
            case "LesserImp": BloodEnemy = 1; speedEnemy = 3.5f; powerEnemy = 20; break;
        }
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.position += Vector3.back * Game_Controller.speed * Time.deltaTime * speedEnemy;
        if (run)
        {
            this.GetComponent<Animator>().Play("Run");
        }

        if (this.BloodEnemy <= 0 && die)
        {
            this.GetComponent<AudioSource>().Play();
            this.GetComponent<Animator>().Play("Die");
            Game_Controller.numEnemy--;
            Destroy(this.gameObject, 3);
            Destroy(this.GetComponent<BoxCollider>());
            Game_Controller.Score += (int)powerEnemy;
            die = false;
        }
        else if (this.BloodEnemy > 0 && !run)
        {
            this.GetComponent<Animator>().Play("Hit");
            run = true;
        }

    }

    void OnTriggerEnter(Collider Other)
    {
        if (Other.name == "Player")
        {
            Game_Controller.CanvasMatMau.SetActive(true);
            game_Controller.GetComponent<Game_Controller>().Health.transform.position -= new Vector3(powerEnemy, 0, 0);
        }
    }

    void OnDestroy()
    {

        if (Game_Controller.CanvasMatMau)
        {
            if (Game_Controller.CanvasMatMau.active)
            {
                Game_Controller.CanvasMatMau.SetActive(false);
            }
        }

    }

}
