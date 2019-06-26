using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnGrenade : MonoBehaviour
{
    Sprite oldImg;
    // Start is called before the first frame update
    void Start()
    {
        if (this.GetComponent<Image>().sprite)
        {
            oldImg = this.GetComponent<Image>().sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick()
    {
        Debug.Log("OnClick");
    }
}
