using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class refSlot : MonoBehaviour , IPointerClickHandler
{
    public GameObject Obj;
    public Ingredient item; //? 인그레디언트 아이템정보
    [SerializeField] Image itemimage;  //? 아이템이미지
    [SerializeField] TextMeshProUGUI text; //? 아이템이름
    [SerializeField] TextMeshProUGUI countText; //? 아이템갯수표현하는텍스트
    public int itmeCount; //? 아이템갯수
    public GameObject go_CountImage; //? 아이템숫자 활성화 : 아이템이1개이상이면 아이템숫자를 활성화 한다 ex) 아이템이 장비탬이면 갯수를 띄울필요가 없음 
    //? 냉장고에 단품으로 들어가야하는 아이템이라면 카운트이미지 꺼버림 

    public GameObject insObj;
    public Queue<float> freshness = new Queue<float>();

    
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        itemimage = gameObject.transform.GetChild(0).GetComponent<Image>();
        SetTextImage();
    }

    //*아이탬획득 
    public void AddItem(GameObject obj, float fresh, int _Count = 1)
    {
        Obj = obj;
        item = obj.GetComponent<Info>().item;
        itmeCount = _Count;
        itemimage.sprite = item.image;
        text.text = item.name;
        freshness.Enqueue(fresh);
        


        if(item.itemType != Ingredient.ItemType.LiveThings) //! 아이템타입이 라이브띵이아니라면 아이탬겟수 활성화 
        {
            go_CountImage.SetActive(true);
            countText.text = itmeCount.ToString();
        }
        else
        {
            countText.text = "0";
            go_CountImage.SetActive(false);
        }

        SetColor(1);
    }

    //*색깔조정 아이템이없으면 슬롯색깔없음 
    private void SetColor(float _alpha)
    {
        Color color = itemimage.color;
        color.a = _alpha;
        itemimage.color = color;
    }
    private void SetTextImage()
    {
        go_CountImage.SetActive(itmeCount > 1);
    }

    //*아이탬겟수
    public void SetSlotCount(int _count)
    {
        itmeCount += _count;
        countText.text = itmeCount.ToString();

        if(itmeCount <= 0)
        {
            ClearSlot();
        }
    }

    //*슬롯초기화
    private void ClearSlot()
    {
        item = null;
        Obj = null;
        itmeCount = 0;
        itemimage.sprite = null;
        SetColor(0);

        countText.text = "0";
        text.text = ""; 
        go_CountImage.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        string a = this.transform.parent.transform.parent.transform.name;
        if(a.Contains("Box"))
        {
            Box(eventData);
        }
        else if(a.Contains("refriger"))
        {
            Refriger(eventData);
        }
    }

    void Refriger(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("ref");
            if(item != null)
            {
                if(item.itemType == Ingredient.ItemType.LiveThings)
                {
                    //! 생물일경우
                    Debug.Log(item.name +" 을 사용했습니다.");
                    Instantiate(item.prefab, insObj.transform.position, Quaternion.identity);
                    item.prefab.GetComponent<SpriteRenderer>().sortingOrder = 2;
                    item.prefab.gameObject.GetComponent<FoodInfo>().freshness = freshness.Dequeue();
                }
                else if (item.itemType == Ingredient.ItemType.vegetable)
                {
                    Debug.Log(item.name +" 을 사용했습니다.");
                    Instantiate(item.prefab, insObj.transform.position, Quaternion.identity);
                    item.prefab.GetComponent<SpriteRenderer>().sortingOrder = 2;
                    Debug.Log(freshness.Peek());
                    item.prefab.gameObject.GetComponent<FoodInfo>().freshness = freshness.Dequeue();
                    SetSlotCount(-1);
                }
            }
        }
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            DataDisplayer dataDisplayer;
            dataDisplayer = GameObject.FindObjectOfType<DataDisplayer>();
            dataDisplayer.panel.gameObject.SetActive(true);
            dataDisplayer.Display(Obj);
        }
    }

    void Box(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("box");
            if(item != null)
            {
                if(item.itemType == Ingredient.ItemType.LiveThings)
                {
                Obj.GetComponent<Info>().GetComponent<Ingredient>();
                    //! 생물일경우
                    Debug.Log(item.name +" 을 냉장고로 이동시켰습니다.");
                    refrigerater refriger = GameObject.FindObjectOfType<refrigerater>();
                    refriger.AcquireItem(Obj, freshness.Dequeue());

                    SetSlotCount(-1);
                }
                else if (item.itemType == Ingredient.ItemType.vegetable)
                {
                    Debug.Log(item.name +" 을 냉장고로 이동시켰습니다.");
                    refrigerater refriger = GameObject.FindObjectOfType<refrigerater>();
                    refriger.AcquireItem(Obj, freshness.Dequeue());
                    SetSlotCount(-1);
                }
            }
        }
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            DataDisplayer dataDisplayer;
            dataDisplayer = GameObject.FindObjectOfType<DataDisplayer>();
            dataDisplayer.Display(Obj);
        }
    }
}
