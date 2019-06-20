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
            Destroy(this.gameObject);
        }
            
        
    }
    void OnTriggerEnter(Collider Other)
    {
        if(Other.tag == "Weapon")
        {
            if(this.name == "Ammo(Clone)")
            {
                Game_Controller.Bullet += 100;
                Game_Controller.numBulletPlus--;
            }
            
            else if(this.name == "Potion_Health(Clone)")
            {
                if(game_Controller.GetComponent<Game_Controller>().Health.transform.localPosition.x < 0)
                {
                    Debug.Log("Cong Mau");
                    game_Controller.GetComponent<Game_Controller>().Health.transform.position += new Vector3(30, 0, 0);
                }
                
                Game_Controller.numHealth--;
            }
            
            Destroy(this.gameObject);

        }
    }


}
