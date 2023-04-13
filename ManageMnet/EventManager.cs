using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField]refrigerater refscript;
    [SerializeField] BoxScript box;
    [SerializeField] CoppiingBoard chop;
    StoveEvent stove;
    DragManager drag;

    public Ingredient ing;

    void Start()
    {
        chop = GameObject.FindObjectOfType<CoppiingBoard>();
        drag = GameObject.FindObjectOfType<DragManager>();
        refscript = GameObject.FindObjectOfType<refrigerater>();
        box = GameObject.FindObjectOfType<BoxScript>();
        stove = GameObject.FindObjectOfType<StoveEvent>();
    }

  public void ToolEvent(string name)
  {
    switch(name)
        {
            case "Pot" :
                Debug.Log("PotEvent");
                break;
            case "Sink" :
                Debug.Log("sinkevent");
                break;
            case "Choppingboard" :
                Debug.Log("Chopevent");
                chop.ChopboardOpen();
                break;
            case "Stove" : 
                stove.StoveEvent1(drag.controllObj);    
                break;
            case "Refrigerater" :
                Debug.Log("Refrigerater");
                refscript.RefOpen();
                break;
            case "cooktable" :
                Debug.Log("cooktable");
                break;
            case "OrderBox" :
                box.BoxOpen();
                break;
        }
    }
 
}
