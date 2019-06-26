using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{

    GunController gunController;
    GameObject[] gun;
    public GameObject grenade;
    void Awake()
    {
        gun = GameObject.FindGameObjectsWithTag("Weapon");
    }
    // Start is called before the first frame update
    void Start()
    {
        
        gunController = gun[0].GetComponent<GunController>();
        grenade = GameObject.Find("Canvas_Items");


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MouseDown()
    {
        bool arrayActive = false;
        foreach (GameObject a in gun)
        {
            if (a.active == true)
            {
                arrayActive = true;
                gunController = a.GetComponent<GunController>();
                gunController.LeftMouseDown();
                break;
            }
        }
        if(!arrayActive && grenade.active == true)
             grenade.GetComponent<GrenadeScript>().DownGrenade();
            
        
    }

    public void MouseOn()
    {
        foreach (GameObject a in gun)
        {
            if (a.active == true && grenade.active == false)
            {
                gunController.LeftMouseOn();
            }
        }
    }


}
