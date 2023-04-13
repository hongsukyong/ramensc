using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveEvent : MonoBehaviour
{  
    [SerializeField] GameObject slot1;
    [SerializeField] GameObject slot2;
    [SerializeField] Frypan c_frypan;
    [SerializeField] StoveDb dataBase;
    [SerializeField] GameObject fpReturn;
    
    void Start()
    {
        dataBase = GameObject.FindObjectOfType<StoveDb>();
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
        dataBase.DataInput(A);
        SpawnItem();
    }

    void SpawnItem()
    {
        ItemDatabase itemDb = GameObject.FindObjectOfType<ItemDatabase>();
        Ingredient A = dataBase.returnItem;
        for(int i = 0; i < itemDb.ingredientItem.Count; i++)
        {
            if(A.ingredientName == itemDb.ingredientItem[i].GetComponent<Info>().item.ingredientName)
            {
               Instantiate(itemDb.ingredientItem[i], slot1.transform);
               Destroy(dataBase.inputItem);
               return;
            }
        }
    }
}
