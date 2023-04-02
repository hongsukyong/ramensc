using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField]refrigerater refscript;
    [SerializeField] BoxScript box;
    [SerializeField] CoppiingBoard chop;

    public Ingredient ing;

    void Start()
    {
        refscript = GameObject.FindObjectOfType<refrigerater>();
        box = GameObject.FindObjectOfType<BoxScript>();
        
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
                Debug.Log("fireevent");
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
