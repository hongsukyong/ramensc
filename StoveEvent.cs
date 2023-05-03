using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveEvent : MonoBehaviour
{  
    [SerializeField] GameObject slot1;
    public GameObject slot2;
    [SerializeField] Frypan c_frypan;
    [SerializeField] StoveDb dataBase;
    [SerializeField] GameObject fpReturn;
    DragManager drag;
    public GameObject insObj;
    ItemDatabase itemDb;
    PotEventDatabase potDb;
    PotEvent potEvent;
    public GameObject a;
    

    
    void Start()
    {
        drag = GameObject.FindObjectOfType<DragManager>();
        dataBase = GameObject.FindObjectOfType<StoveDb>();
        itemDb = GameObject.FindObjectOfType<ItemDatabase>();
        potDb = GameObject.FindObjectOfType<PotEventDatabase>();
        potEvent = GameObject.FindObjectOfType<PotEvent>();
        CurrentFrypan();
    }

    void CurrentFrypan()
    {
        c_frypan = GameObject.FindObjectOfType<FrypanInfo>().item;
        dataBase = GameObject.FindObjectOfType<StoveDb>();
        
        GameObject a = GameObject.FindObjectOfType<FrypanInfo>().gameObject;
        a.transform.localPosition = new Vector3
        ( 
            (slot1.transform.localPosition.x - 0.1f),
             slot1.transform.localPosition.y,
             slot1.transform.localPosition.z 
        );
    }

    public void StoveEvent1(GameObject A)
    {
        Debug.Log(A.GetComponent<Info>().item.fry);
        if(A.GetComponent<Info>().item.fry)
        {
            
            dataBase.DataInput(A);
            SpawnItem();
            drag.controllObj = null;
        }
        slot1.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        
    }

    void SpawnItem()
    {
        
        Ingredient A = dataBase.returnItem;
        for(int i = 0; i < itemDb.ingredientItem.Count; i++)
        {
            if(A.ingredientName == itemDb.ingredientItem[i].GetComponent<Info>().item.ingredientName)
            {
                insObj = itemDb.ingredientItem[i];
               Instantiate(insObj, slot1.transform);
               Destroy(dataBase.inputItem);
               return;
            }
        }
    }
    public void SlotColControll()
    {
        slot1.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void StoveEvent2(GameObject b)
    {
        Debug.Log(b);
       a = b;
       if(b == null)
       {
            potEvent.IsPanelOppen(true);
            potEvent.ButtonOnOff();
       }
       else
       {
            if(b.name.Contains("Noodle"))
            {
                 NoodleEvent();
                 return;
            }
            else if(b.name.Contains("Soup"))
            {
                SoupEvent();
                return;
            }
            else
            {
                potEvent.IsPanelOppen(true);
                potEvent.ButtonOnOff();
            }
       }
    }
    void NoodleEvent()
    {
        potEvent.AddNoddle();
    }
    void SoupEvent()
    {
        potEvent.AddSoup();
    }
}
