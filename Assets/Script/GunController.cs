using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
    public GameObject Effect;
    public GameObject BulletLine;
    public GameObject HongSung;
    Vector3 posHongSung;
    AudioClip oldAudio;
	// Use this for initialization
	void Start () {
        posHongSung = HongSung.transform.position;
        oldAudio = this.GetComponent<AudioSource>().clip;
	}
	
	// Update is called once per frame
	void Update () {

        //if (Input.GetMouseButtonDown(0))
        //{

        //    if (Game_Controller.Bullet <= 0)
        //    {
        //        this.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Audio/they shoot");
        //        this.GetComponent<AudioSource>().Play();
        //    }
        //    else
        //    {
        //        GameObject effect = Instantiate(Effect, HongSung.transform.position, Quaternion.identity);
        //        Destroy(effect, 0.5f);

        //        GameObject bulletLine = Instantiate(BulletLine);
        //        bulletLine.transform.parent = HongSung.transform;
        //        bulletLine.transform.position = HongSung.transform.position;
        //        bulletLine.transform.localPosition = new Vector3(0, 0, 0);
        //        bulletLine.transform.localRotation = new Quaternion(0, 0, 0, 0);
        //        Destroy(bulletLine, 1f);
        //        this.GetComponent<AudioSource>().clip = oldAudio;
        //        this.GetComponent<AudioSource>().Play();
        //        Game_Controller.Bullet--;
        //    }

        //}
        //if (Input.GetMouseButtonUp(0))
        //{
        //    this.GetComponent<AudioSource>().Stop();
        //}
    }

    public void LeftMouseDown()
    {
        if (Game_Controller.Bullet <= 0)
        {
            this.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Audio/they shoot");
            this.GetComponent<AudioSource>().Play();
        }
        else
        {
            GameObject effect = Instantiate(Effect, HongSung.transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);

            GameObject bulletLine = Instantiate(BulletLine);
            bulletLine.transform.parent = HongSung.transform;
            bulletLine.transform.position = HongSung.transform.position;
            bulletLine.transform.localPosition = new Vector3(0, 0, 0);
            bulletLine.transform.localRotation = new Quaternion(0, 0, 0, 0);
            Destroy(bulletLine, 1f);
            this.GetComponent<AudioSource>().clip = oldAudio;
            this.GetComponent<AudioSource>().Play();
            Game_Controller.Bullet--;
        }
    }

    public void LeftMouseOn()
    {
        this.GetComponent<AudioSource>().Stop();
    }
}
