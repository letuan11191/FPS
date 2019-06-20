using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

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
        Destroy(this);
    }
}
