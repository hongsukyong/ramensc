using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragManager : MonoBehaviour
{
    RaycastHit2D Hit; //? 클릭시 정보를 가져올 레이케스트 
    [SerializeField] Vector2 mousePos; //? 마우스 이동할 때 오브젝트가 마우스를 따라오기 위해서 마우스 위치값;
    [SerializeField] bool draging; //? 드래그중인지아닌지 불값
    [SerializeField] GameObject clickObj; //? 클릭한 오브젝트 
    public GameObject controllObj; //? 현재 들고 이동중인 오브젝트

    BoxCollider2D col;
    [SerializeField] bool dragready;

    EventManager eventManager;
    [SerializeField] GameManager gameManager;
    DataDisplayer dataDisplayer;
    StoveEvent stove;
    TagController tagC;

    void Ready()
    {
        gameManager.ConfirmDrag();
        dragready = gameManager.canDrag;
    }
    
    void Start()
    {
        tagC = GameObject.FindObjectOfType<TagController>();
        stove = GameObject.FindObjectOfType<StoveEvent>();
        gameManager = gameManager.GetComponent<GameManager>();
        eventManager = gameManager.GetComponent<EventManager>();
        dataDisplayer = FindObjectOfType<DataDisplayer>();
    }

    void Update()
    {
        Drag();
    }

    void Drag()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ready();

            if(dragready)
            {
                DragSystem();
            }
        }

        if(draging)
        {
            ObjectPosControll();
        }
    }

    void DragSystem()
    {
        BringInfo();
        tagC.PotTagChange();
        

        if (!draging)
        {
            if (clickObj != null)
            {
                ObjEvent();

                if(stove.insObj != null)
                if (clickObj == stove.insObj)
                {
                    stove.SlotColControll();
                }
            }
        }
        else
        {
            EndDrag();
        }

        
        
    }
    void BringInfo()
    {
        PositionInfo();

        if(Hit.collider)
        {
            ClickInfo();
        }
        else 
        {
            clickObj = null;
        }
    }

    void PositionInfo()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Hit = Physics2D.Raycast(mousePos, Vector2.zero);
    }

    void ClickInfo()
    {
        if(Hit.collider.gameObject != null)
        {
            clickObj = Hit.collider.gameObject;
            Debug.Log("lickObj : " + clickObj);
        }
    }
    void ObjEvent()
    {
        
        if(clickObj.gameObject.tag == "dragable")
        {
            StartDrag();
        }
        else if(clickObj.gameObject.tag == "eventtool")
        {
            TableEvent();
        }
    }
    void StartDrag()
    {
        controllObj = clickObj;
        draging = true;
        ColiderControll();
        tagC.PotTagChange();
    }

    void ObjectPosControll()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        controllObj.gameObject.transform.position = mousePos;
        
    }

    void ColiderControll()
    {
        col = controllObj.GetComponent<BoxCollider2D>();
        col.enabled = !draging;
    }

    void EndDrag()
    {
        draging = false;
        ColiderControll();

        controllObj.gameObject.transform.position = controllObj.gameObject.transform.position;

        if(clickObj != null)
        if(clickObj.gameObject.tag == "eventtool")
        {
            TableEvent();
        }

        clickObj = null;
        controllObj = null;
    }
    void TableEvent()
    {
        string a = clickObj.gameObject.GetComponent<ToolInfo>().toolName;
        eventManager.ToolEvent(a);
    }


}
