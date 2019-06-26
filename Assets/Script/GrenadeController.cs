using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour
{
    public GameObject Explosion;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision Other)
    {
        if (Other.transform.tag == "Ground")
        {
            GameObject[] lstEnemy = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject a in lstEnemy)
            {
                if (Vector3.Distance(a.transform.position, this.transform.position) <= 5)
                {
                    Destroy(a);

                    Game_Controller.numEnemy--;
                }
                this.GetComponent<AudioSource>().Play();
                Destroy(Instantiate(Explosion, this.transform.position, Quaternion.identity), 4);

            }

            GameObject boss = GameObject.Find("Boss");
            if (boss)
            {
                if (Vector3.Distance(boss.transform.position, this.transform.position) <= 5)
                {
                    GameObject gameController = GameObject.Find("Game_Controller");
                    gameController.GetComponent<Game_Controller>().BossHealth.transform.position -= new Vector3(3, 0, 0);
                }
            }
            GameObject energyBall = GameObject.FindGameObjectWithTag("Energy");
            if (energyBall)
            {
                if (Vector3.Distance(energyBall.transform.position, this.transform.position) <= 5)
                    Destroy(energyBall);
            }
            Destroy(this.gameObject, 2);
        }
        
    }
}
