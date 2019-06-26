using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject Effect;
    public GameObject BulletLine;
    public GameObject HongSung;
    Vector3 posHongSung;
    AudioClip oldAudio;
    // Use this for initialization
    void Start()
    {
        posHongSung = HongSung.transform.position;
        oldAudio = this.GetComponent<AudioSource>().clip;
    }

    // Update is called once per frame
    void Update()
    {

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
        if (this.transform.name == "Pistol")
        {
            GameObject effect = Instantiate(Effect, HongSung.transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            this.GetComponent<AudioSource>().clip = oldAudio;
            this.GetComponent<AudioSource>().Play();
            this.GetComponent<Animation>().Play("Fire");
            CreateBulletLine();


        }
        else
        {
            if (Game_Controller.bulletShotGun <= 0 || Game_Controller.bulletUMP40 <= 0)
            {
                this.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Audio/they shoot");
                this.GetComponent<AudioSource>().Play();
            }
            else
            {
                GameObject effect = Instantiate(Effect, HongSung.transform.position, Quaternion.identity);
                Destroy(effect, 0.5f);
                this.GetComponent<AudioSource>().clip = oldAudio;
                this.GetComponent<AudioSource>().Play();
                this.GetComponent<Animation>().Play("Fire");
                if (this.transform.name == "UMP40")
                {
                    for (int i = 1; i < 8; i++)
                    {
                        CreateBulletLine();
                    }
                    Game_Controller.bulletUMP40 -= 5;
                }
                else
                {
                    CreateBulletLine();
                    Game_Controller.bulletShotGun -= 3;
                }
            }
        }



    }

    public void LeftMouseOn()
    {
        this.GetComponent<AudioSource>().Stop();
        this.GetComponent<Animation>().Stop();
    }

    public void CreateBulletLine()
    {
        GameObject bulletLine = Instantiate(BulletLine);
        bulletLine.transform.parent = HongSung.transform;
        bulletLine.transform.position = HongSung.transform.position;
        bulletLine.transform.localPosition = new Vector3(0, 0, 0);
        bulletLine.transform.localRotation = new Quaternion(0, 0, 0, 0);
        Destroy(bulletLine, 1f);
    }

}
