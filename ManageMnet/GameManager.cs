using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    refrigerater refscript;
    public bool canDrag;
    BoxScript box;
    DeliveryOrder deliveryOrder;
    DataDisplayer dataDisplayer;

    void Start()
    {
        refscript = GameObject.FindObjectOfType<refrigerater>();
        box = GameObject.FindObjectOfType<BoxScript>();
        deliveryOrder = GameObject.FindObjectOfType<DeliveryOrder>();    
        dataDisplayer = GameManager.FindObjectOfType<DataDisplayer>();

        ConfirmDrag();
    }

    public void ConfirmDrag()
    {
        if(box.panelopen || refscript.panelopen || deliveryOrder.p_Panel.activeSelf || dataDisplayer.isOn)
        {
            canDrag = false;
        }
        else
        {
            canDrag = true;
        }


    }
}
