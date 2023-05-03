using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotEvent : MonoBehaviour
{
    public GameObject slotP;   //? 슬롯패런츠 냄비 를 누르면 가장 먼저 켜져야하는 게임오브젝트 
    public GameObject potReset; //? 냄비가 비어있으면 꺼져야함 냄비를 초기화 하기위한 버튼
    public GameObject addIngredient;    //? 재료넣기 냄비에 있는 아이템 넘버를 받아서 숫자를 추가하기 위해 있음 재료를 들고있음에 따라 온오프 해야됨
    public GameObject addWater; //?냄비에 물 추가하기 위한 버튼 냄비에 물을 판단해서 게임오브젝트 setactive 온오프 해야함
    public int c_ItemNumber;                             //? 아이템번호를 가져와서 합계시켜서 아이템리스트에서 리턴값을 뽑는 역할 
    float c_Fresh;  //! 신선도 가져오기 위한 플롯인수 신선도를 가져오는 방법 생각해볼것 
    public GameObject returnObj;
    PotSpriteDatabase potImgDb;
    public GameObject water;
    public GameObject noodle;
    public GameObject topping;

    PotEventDatabase potDb;
    public bool pOpen;
    DragManager dragManager;
    StoveEvent stove;

    void Awake()
    {
        potDb = GameObject.FindObjectOfType<PotEventDatabase>();
        slotP.gameObject.SetActive(false);
        potImgDb = GameObject.FindObjectOfType<PotSpriteDatabase>();
        dragManager = GameObject.FindObjectOfType<DragManager>();
        stove = GameObject.FindObjectOfType<StoveEvent>();
    }

    void Start()
    {
        ButtonOnOff();
    }
    
    public void ButtonOnOff()
    {
        DragManager drag; 
        drag = GameObject.FindObjectOfType<DragManager>();

        if(drag.controllObj == null)
        {
            addIngredient.gameObject.SetActive(false);
        }
        else 
        {
            addIngredient.gameObject.SetActive(true);
        }


        if (c_ItemNumber != 0)
        {
            potReset.gameObject.SetActive(true);
        }
        else 
        {
            potReset.gameObject.SetActive(false);
        }

        if(c_ItemNumber <= 10000)
        {
            addWater.gameObject.SetActive(true);
        }
        else
        {
            addWater.gameObject.SetActive(false);
        }
        if(addWater.gameObject.activeSelf)
        {
            returnObj.gameObject.SetActive(false);
        }
        else
        {
            returnObj.gameObject.SetActive(true);
        }

        
    }
    public void AddWater()
    {
        c_ItemNumber += 10000;
        IsPanelOppen(false);
        WaterReturn();
    }
    public void AddNoddle()
    {
        c_ItemNumber += stove.a.gameObject.GetComponent<Info>().item.itemNumber;
        NoodelReturn();

        IsPanelOppen(false);
    }
    public void AddSoup()
    {
        if(stove.a.gameObject.GetComponent<Info>() != null)
        {
            if(stove.a.gameObject.GetComponent<Info>().item != null)
            {
                if(c_ItemNumber >= 10000)
                {
                    c_ItemNumber -= 10000;
                }
                Debug.Log(stove.a.gameObject.GetComponent<Info>().item.itemNumber);
                c_ItemNumber += stove.a.gameObject.GetComponent<Info>().item.itemNumber;
                WaterReturn();
            }
        }
        IsPanelOppen(false);
    }
    public void AddTopping()
    {
        if(stove.a.gameObject.GetComponent<Info>() != null)
        {
            if(stove.a.gameObject.GetComponent<Info>().item != null)
            {
                c_ItemNumber += stove.a.gameObject.GetComponent<Info>().item.itemNumber;
                ToppingReturn();
            }
            IsPanelOppen(false);
        } 
        
    }

    public void IsPanelOppen(bool a)     //? 판넬이 오픈되었는지 확인하는 함수 게임메니저에서 드레그 or 클릭 가능 여부를 제어하기 위함 
    {
         slotP.gameObject.SetActive(a);
        pOpen = slotP.gameObject.activeSelf;
    }




    public void PotToIngredient(GameObject _g)   //? 아이템 추가하면 넘버에 +시키는 역활 
    {                                           //todo 신선도도 같이 넘겨야함 
        Ingredient i = _g.GetComponent<Info>().item;
        int a = i.itemNumber;

        c_ItemNumber = +i.itemNumber;

        Debug.Log("냄비 아이템넘버 합계 = " + c_ItemNumber);
    }

    void WaterReturn()             
    {                                
        
        if (c_ItemNumber != 0)
        {
            for (int i = 0; i < potImgDb.potImg.Count; i++)
            {
                Debug.Log(c_ItemNumber/1000);
                if (c_ItemNumber/1000 == potImgDb.potImg[i].spriteNum/1000)
                {
                    Debug.Log(potImgDb.potImg[i].spriteNum);
                    water.gameObject.GetComponent<SpriteRenderer>().sprite = potImgDb.potImg[i].img;
                    return;
                }
            }
        }
    }

    void NoodelReturn()
    {
        Debug.Log("addnoodle");
        if(c_ItemNumber != 0)
        {
            for (int i = 0; i < potImgDb.ndlImg.Count; i++)
            {
                Debug.Log(c_ItemNumber%1000 / 100);
                
                if(c_ItemNumber%1000/100 <= potImgDb.ndlImg[i].spriteNum/100)
                {
                    
                    noodle.gameObject.GetComponent<SpriteRenderer>().sprite = potImgDb.ndlImg[i].img;
                    Destroy(stove.a.transform.gameObject, 0.1f);
                    return;
                }
            }
        }   
    }

    void ToppingReturn()
    {
        Debug.Log("1");
        if(c_ItemNumber != 0)
        {
            Debug.Log("2");
            for(int i = 0; i < potImgDb.tpImg.Count; i++)
            {
                Debug.Log(c_ItemNumber%100);
                if(c_ItemNumber%100 == potImgDb.tpImg[i].spriteNum)
                {
                    Debug.Log("토핑리턴");
                    topping.gameObject.GetComponent<SpriteRenderer>().sprite = potImgDb.tpImg[i].img;
                    Destroy(stove.a.transform.gameObject, 0.1f);
                    return;
                }
            }
        }
    }
    //Todo 끓이기 버튼을 어떻게 만들것인가, 라면 완성 버튼을 누르면 그릇으로 변경할지 냄비로 나갈지 선택해야함 

    public void PotReset()
    {
        c_ItemNumber = 0;
        topping.GetComponent<SpriteRenderer>().sprite = null;
        water.GetComponent<SpriteRenderer>().sprite = null;
        IsPanelOppen(false);
    }
}
