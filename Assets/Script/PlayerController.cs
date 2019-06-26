using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public NewVirtualJoyStick VirtualJoyStick;

    float getHorizontal;
    float getVertical;

    public GameObject Cam;
    public GameObject Gun;

    GameObject game_Controller;


    int speed;

    Touch initTouch = new Touch();
    Touch touch;

    float rotX = 0f;
    float rotY = 0f;
    Vector3 oriRot;

    public float speedRot = 0.5f;
    public float dir = -1;

    // Use this for initialization
    void Start () {
        game_Controller = GameObject.Find("Game_Controller");
        //Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        speed = 10;
        getVertical = 0;
        getHorizontal = 0;

        touch = new Touch();
        oriRot = Cam.transform.eulerAngles;
        rotX = oriRot.x;
        rotY = oriRot.y;


        //use for muose//
        //Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void Update () {
        //use Mouse//
        //getHorizontal += speed * Input.GetAxis("Mouse Y");
        //getVertical += speed * Input.GetAxis("Mouse X");
        //Cam.transform.localEulerAngles = new Vector3(-getHorizontal, getVertical, 0);

        //Gun.transform.eulerAngles = new Vector3(getHorizontal, getVertical, 0);

        //if (Cam.transform.localRotation.y >= 70)
        //{
        //    Cam.transform.localRotation = new Quaternion(0, 70, 0, 0);
        //}
        //if (Cam.transform.localRotation.y <= -70)
        //{
        //    Cam.transform.localRotation = new Quaternion(0, -70, 0, 0);
        //}
    }

    public float sR = 5;
    void FixedUpdate()
    {
        ////user Joystick//
        getHorizontal += VirtualJoyStick.Horizontal();
        getVertical -= VirtualJoyStick.Vertical();
        getVertical = Mathf.Clamp(getVertical, -45f, 45f);
        getHorizontal = Mathf.Clamp(getHorizontal, -45f, 45f);
        Cam.transform.localEulerAngles = new Vector3(getVertical, getHorizontal, 0) * sR * Time.deltaTime;
        ///////////////////////////////////////////////////////////////////////////////////////////////////



        //touch = Input.GetTouch(0);
        //if (touch.phase == UnityEngine.TouchPhase.Began)
        //{
        //    initTouch = touch;
        //}
        //else if (touch.phase == UnityEngine.TouchPhase.Moved)
        //{
        //    float deltaX = initTouch.position.x - touch.position.x;
        //    float deltaY = initTouch.position.y - touch.position.y;
        //    rotX -= deltaY * Time.deltaTime * speedRot * dir;
        //    rotY += deltaX * Time.deltaTime * speedRot* dir;
        //    Cam.transform.eulerAngles = new Vector3(rotX, rotY, 0f);


        //}
        //else if (touch.phase == UnityEngine.TouchPhase.Ended)
        //{
        //    initTouch = new Touch();
        //}

    }
        void OnCollisionExit(Collision Other)
    {
        
    }

    
    void OnTriggerExit(Collider Other)
    {
        if (Other.tag == "Enemy")
        {
            Game_Controller.CanvasMatMau.SetActive(false);
        }
        if (Other.tag == "Ground")
        {
            RectTransform rt1 = (RectTransform)Other.transform;
            Other.transform.position = new Vector3(Other.transform.position.x, Other.transform.position.y, Other.transform.position.z + (rt1.rect.width * 2));
        }

    }

    void OnTriggerEnter(Collider Other)
    {

    }
}


