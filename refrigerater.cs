using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class refrigerater : MonoBehaviour 
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject onOff;
    [SerializeField] GameObject slot;

    public bool panelopen;
    [SerializeField] GameManager gameManager;


    public static bool inventoryActivated = false;
    private GameObject inventorybase;
    [SerializeField] private GameObject go_slotParent;
    public refSlot[] slots;

    public Ingredient ingredient;

    void Start()
    {
        slots = go_slotParent.GetComponentsInChildren<refSlot>();
    }

    void Update()
    {
        
    }


    
    public void RefOnOff()
    {
        panel.gameObject.SetActive(!panel.activeSelf);
        PanelOpen();
        
    }
    
    public void RefOpen()
    {
        panel.gameObject.SetActive(true);
        PanelOpen();
    }

    void PanelOpen()
    {
        panelopen = panel.gameObject.activeSelf;
        gameManager.ConfirmDrag();
    }

    public void AcquireItem(GameObject _obj, float fresh, int _count = 1)                           //? 슥듭합니다 아이템을 카운트만큼
    {
        Ingredient _item =_obj.gameObject.GetComponent<Info>().item;
        //fresh = _obj.GetComponent<FoodInfo>().freshness;

        if(_item.itemType != Ingredient.ItemType.LiveThings)                            //? (_item)의 타입이 생물재료가 아니라면 
        {
            for(int i= 0; i <slots.Length; i++)                                         //? i는 슬롯의 길이만큼 반복되는동안
            {
                if(slots[i].item != null)                                               //? 슬롯i번째 아이템이 있다면
                {
                    if(slots[i].item.ingredientName == _item.ingredientName)            //? 슬롯의 i번째의 아이템 이름이 추가할 아이템이름과 같다면 
                    {
                        slots[i].SetSlotCount(_count);                                  //? 슬롯카운트를 변경합니다 (_카운트만큼)
                        slots[i].freshness.Enqueue(fresh);
                        return;
                    }   
                }
            }
        }
        for(int i= 0; i <slots.Length; i++)                                             //? i가 슬롯의 길이만큼 반복합니다 
        {
            if(slots[i].item == null)                                                   //? (_item)의 타입이 생물재료가 아니라면 
            {
                slots[i].AddItem(_obj, fresh,  _count);                                        //? _item을 카운트만큼 추가합니다
                return;
            }
        }

    }

    public void UseItem()
    {
        
    }

    /* 
    //! 아직 사용안하는 스크립트 
    public void RefrigerClass() //? 인벤토리 슬롯 생성 for instantiate
    {
        Instantiate(slot, go_slotParent.transform);
    }
    */
}
