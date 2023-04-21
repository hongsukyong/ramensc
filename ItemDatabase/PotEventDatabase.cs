using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotEventDatabase : MonoBehaviour
{
    public List<GameObject> itemList = new List<GameObject>();      //? 완성된 아이템을 가져올 아이템 배열, 아이탬 딕셔너리 라고 생각하면 편함 
    public List<GameObject> c_Item = new List<GameObject>();        //? 현제 어떤 아이템이 있는지 확인하는 배열, 나중에 테스트하면 없애도 됨
    [SerializedField] int c_ItemNumber;                             //? 아이템번호를 가져와서 합계시켜서 아이템리스트에서 리턴값을 뽑는 역할 
    [SerializedField] float c_Fresh;  //! 신선도 가져오기 위한 플롯인수 신선도를 가져오는 방법 생각해볼것 


    /*
        !폐기 
        Todo:   팟이벤트 1 번은 재료와 냄비의 상호작용을 리턴하는 게임오브젝트 
                팟이벤트 2 번은 라면과 냄비의 상호작용을 리턴하는 게임오브젝트 
                팟이벤트 3예정은 재료와 라면이 합쳐졌을때 상호작용 
                
                필요한것 상호작용 함수 
                인풋 게임오브젝트가 있으면 함수를 리턴하는 void 
                
    */



    void start()    //? 시작하면 아이템점수를 초기화 시키고 아이템이 들어있는 상태에서 초기화 한다면 아이템들어있는 배열(c_item) 에서 아이템 넘버를 찾아와서 더하기 시키는 과정 
    {               //Todo 아이템 넘버가 넘어오는지 확인할 필요 있음
        c_ItemNumber = 0;       //? 아이템넘버는 0이다; 초기화
        
        if(c_Item != null)      //? 현제 아이템이 null이 아니라면 
        {
            
            for(int i = 0; i < c_Item.Count; i++)
            {
                int number = c_Item[i].GetComponent<Info>().itemNumber;
               c_ItemNumber += number;
            }
        }   //! 아이템넘버를 0으로 만들지 않으면 껏다켜도 상관없겠지만 저장할 때 가져오다가 숫자가 꼬일 수 잇으니 정리를 위한 0 으로 만들기임 나중에 없애는것도 생각해 볼 수 있음 
    }

    public void PotToIngredient(GameObject _g)   //? 아이템 추가하면 넘버에 +시키는 역활 
    {                                           //todo 신선도도 같이 넘겨야함 
        Ingredient i = _g.GetComponent<Info>().item;
        int a = i.itemNumber;
        
        c_ItemNumber =+ i.itemNumber;

        Debug.Log("냄비 아이템넘버 합계 = " + c_ItemNumber);
    }

    public void PotReturn()             //? 아이탬을 추가해서 합계시켰던 재료들이 숫자로 표현되어 있으니 아이템리스트에서 같은 숫자를 찾아서 리턴하는 과정 
    {                                   //Todo 신선도와 재료의 수치는 같이 옮겨져야함 
        if(c_ItemNumber != 0)
        {
            for(int i = 0; i < itemList.count;  i++)
            {
                if(c_ItemNumber == itemList[i].GetComponent<Info>().item.itemNumber)
                {
                    Instacitate(itemList[i].GameObject);
                }
            }
        }
    }
    

}