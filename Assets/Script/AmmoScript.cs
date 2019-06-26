using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour {

    public GameObject game_Controller;
	// Use this for initialization
	void Start () {
        game_Controller = GameObject.Find("Game_Controller");
	}
	
	// Update is called once per frame
	void Update () {
        
        this.transform.Rotate(new Vector3(0, 10, 0));
        this.transform.Translate(Vector3.down * Time.deltaTime * 0.3f);
        //Destroy(this, 15);
        if (this.transform.position.x < 0)
        {
            if (this.name == "Ammo(Clone)")
                Game_Controller.numBulletPlus--;
            else if (this.name == "Potion_Health(Clone)")
                Game_Controller.numHealth--;
            else if (this.name == "GrenadePlus(Clone)")
                Game_Controller.numGrenadePlus--;
            Destroy(this.gameObject);
        }
            
        
    }
    void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Weapon")
        {
            //if (this.name == "Ammo(Clone)")
            //{
            //    Game_Controller.Bullet += 100;
            //    Game_Controller.numBulletPlus--;
            //}

             if (this.name == "Potion_Health(Clone)")
            {
                if (game_Controller.GetComponent<Game_Controller>().Health.transform.localPosition.x < 0)
                {
                    game_Controller.GetComponent<Game_Controller>().Health.transform.position += new Vector3(30, 0, 0);
                }

                Game_Controller.numHealth--;
            }

            else if (this.name == "GrenadePlus(Clone)")
            {
                
                Game_Controller.numGrenade += 1;
                Game_Controller.numGrenadePlus--;
            }

            else if (this.name == "clock(Clone)")
            {
                Debug.Log("IceTime");
                Time.timeScale = 0.0001f;
                Game_Controller.numTimeIce--;
            }
            else if(this.name == "ShotgunPlus(Clone)")
            {
                Game_Controller.bulletShotGun += 30;
                Game_Controller.numBulletPlus--;
            }
             else if(this.name == "UMP40Plus(Clone)")
            {
                Game_Controller.bulletUMP40 += 30;
                Game_Controller.numBulletPlus--;
            }
            Destroy(this.gameObject);

        }
    }


}
