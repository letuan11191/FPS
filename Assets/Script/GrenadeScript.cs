using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeScript : MonoBehaviour
{
    public GameObject _GameController;
    public GameObject _Cam;
    public GameObject _Player;
    Game_Controller grenadeScript;

    public GameObject Gun;
    public GameObject Shotgun;
    public GameObject UMP40;
    public GameObject ObjGrenade;

    // Start is called before the first frame update
    void Start()
    {
        Shotgun.SetActive(false);
        UMP40.SetActive(false);
        _Player = GameObject.Find("Player");
        _GameController = GameObject.Find("Game_Controller");
        grenadeScript = _GameController.GetComponent<Game_Controller>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCLickBtn()
    {

        UpdateItemChoose("Grenade");
        //if (!clickBtn)
        //{
        //    //this.GetComponent<Image>().sprite = null;
        //    grenadeScript.Grenade.SetActive(true);
        //    Gun.SetActive(false);
        //    clickBtn = true;
        //}

        //else if (clickBtn)
        //{
        //    //this.GetComponent<Image>().sprite = oldImg;
        //    grenadeScript.Grenade.SetActive(false);
        //    Gun.SetActive(true);
        //    clickBtn = false;
        //}

    }

    public void DownGrenade()
    {
        if (Game_Controller.numGrenade > 0)
        {
            float deltaPower = _Cam.transform.localRotation.x * -20;
            GameObject grenadeObj = Instantiate(ObjGrenade, _Cam.transform.position, Quaternion.identity);
            grenadeObj.transform.parent = _Cam.transform;
            grenadeObj.GetComponent<Rigidbody>().isKinematic = false;
            if (deltaPower <= 0)
            {
                deltaPower = 1;
            }
            grenadeObj.GetComponent<Rigidbody>().AddForce(new Vector3(0, 10 * deltaPower, 800 * deltaPower));
            Game_Controller.numGrenade--;
        }
        else
        {
            grenadeScript.Grenade.SetActive(false);
            Gun.SetActive(true);
        }
    }

    public void UpGrenade()
    {

    }

    public void UpdateItemChoose(string name)
    {
        foreach(Transform a in _Player.transform.GetChild(0).transform)
        {
            if(a.name == name)
            {

                a.gameObject.SetActive(true);
                Game_Controller.Gun = a.gameObject;
            }
            else
            {
                a.gameObject.SetActive(false);
            }
        }
    }

    public void BtnPistol()
    {
        UpdateItemChoose("Pistol");
    }
    public void BtnShotgun()
    {
        UpdateItemChoose("Shotgun");
    }
    public void BtnUMP40()
    {
        UpdateItemChoose("UMP40");
    }
}
