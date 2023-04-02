using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    refrigerater refscript;
    public bool canDrag;

    void Start()
    {
        refscript = GameObject.FindObjectOfType<refrigerater>();

        ConfirmDrag();
    }

    public void ConfirmDrag()
    {
        if(!refscript.panelopen)
        {
            canDrag= true;
        }
        else 
        {
            canDrag =false;
        }
    }
}
