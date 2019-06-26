using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyController : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), 0.5f * Time.deltaTime);
    }

    void OnTriggerEnter(Collider Other)
    {
        if (Other.name == "Player")
        {
            GameObject.Find("Game_Controller").GetComponent<Game_Controller>().Health.transform.position -= new Vector3(80, 0, 0);
            Destroy(this.gameObject);
            BossScript.numEnergyBall--;
        }
    }
}
