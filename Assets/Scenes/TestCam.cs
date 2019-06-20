using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCam : MonoBehaviour {
    public NewVirtualJoyStick VirtualJoyStick;
    float getHorizontal = 0;
    float getVertical = 0;
         
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        getHorizontal += VirtualJoyStick.Horizontal();
        getVertical -= VirtualJoyStick.Vertical();
        this.transform.localEulerAngles = new Vector3(getVertical, getHorizontal, 0);
    }
}
