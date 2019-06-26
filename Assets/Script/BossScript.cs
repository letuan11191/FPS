using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject EnergyBall;
    public static int numEnergyBall = 0;
    float timeAttack = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - timeAttack > 5 && numEnergyBall <=5)
        {
            timeAttack = Time.time;
            Attack();
        }
        else
        {
            this.GetComponent<Animator>().Play("Stand");
        }
    }

    void Attack()
    {
        float rdX;
        float rdY;
        rdX = Random.Range(-4, 4);
        rdY = Random.Range(0, 14);

        int rd = Random.Range(0, 5);
        string stringAnim = "attack0" + rd;
        this.GetComponent<Animator>().Play(stringAnim);
        Instantiate(EnergyBall, new Vector3(rdX, rdY, 30), Quaternion.identity);
        numEnergyBall++;
    }

    
}
