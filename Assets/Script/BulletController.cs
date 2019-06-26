using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject gameController;
    // Use this for initialization
    void Start()
    {
        gameController = GameObject.Find("Game_Controller");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Enemy")
        {
            Other.gameObject.GetComponent<EnemyController>().BloodEnemy--;
            Other.gameObject.GetComponent<EnemyController>().run = false;
        }
        if(Other.tag == "Boss")
        {
            gameController.GetComponent<Game_Controller>().BossHealth.transform.position -= new Vector3(3, 0, 0);
            Game_Controller.Score += 50;
        }
        if(Other.tag == "Energy")
        {
            Destroy(Other.gameObject);
            BossScript.numEnergyBall--;
        }
        Destroy(this);
    }
}
