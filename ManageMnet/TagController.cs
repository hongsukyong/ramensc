using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagController : MonoBehaviour
{

    PotEvent potEv;
    public GameObject pot;
    DragManager drag;

    void Start()
    {
        drag = GameObject.FindObjectOfType<DragManager>();
        potEv = GameObject.FindObjectOfType<PotEvent>();
    }
    public void PotTagChange()
    {
        Debug.Log("ddd");
        if(drag.controllObj != null)
        {
            Debug.Log(pot.gameObject.tag);
            pot.gameObject.tag = "eventtool";
        } 
        else 
        {
            pot.gameObject.tag = "dragable";
        }
        
    }
}
