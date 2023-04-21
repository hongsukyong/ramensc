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
                chop.ChopboardOpen(drag.controllObj);
                break;
            case "Stove1" : 
                stove.StoveEvent1(drag.controllObj);    
                break;
            case "Stove2":
                Debug.Log("냄비작업");
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
