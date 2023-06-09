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
    CoppiingBoard coppiingBoard;
    PotEvent pot;
    void Start()
    {
        refscript = GameObject.FindObjectOfType<refrigerater>();
        box = GameObject.FindObjectOfType<BoxScript>();
        deliveryOrder = GameObject.FindObjectOfType<DeliveryOrder>();    
        dataDisplayer = GameObject.FindObjectOfType<DataDisplayer>();
        coppiingBoard = GameObject.FindObjectOfType<CoppiingBoard>();
        pot = GameObject.FindObjectOfType<PotEvent>();

        ConfirmDrag();
    }

    public void ConfirmDrag()
    {
        if(box.panelopen || refscript.panelopen || deliveryOrder.p_Panel.activeSelf || dataDisplayer.isOn || coppiingBoard.actionP.activeSelf || pot.pOpen)
        {
            canDrag = false;
        }
        else
        {
            canDrag = true;
        }


    }
}
