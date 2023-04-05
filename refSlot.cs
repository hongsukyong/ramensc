using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class refSlot : MonoBehaviour , IPointerClickHandler
{
    public List<float> freshness = new List<float>();
    public GameObject Obj;
    public Ingredient item; //? 인그레디언트 아이템정보
    [SerializeField] Image itemimage;  //? 아이템이미지
    [SerializeField] TextMeshProUGUI text; //? 아이템이름
    [SerializeField] TextMeshProUGUI countText; //? 아이템갯수표현하는텍스트
    public int itmeCount; //? 아이템갯수
    public GameObject go_CountImage; //? 아이템숫자 활성화 : 아이템이1개이상이면 아이템숫자를 활성화 한다 ex) 아이템이 장비탬이면 갯수를 띄울필요가 없음 
    //? 냉장고에 단품으로 들어가야하는 아이템이라면 카운트이미지 꺼버림 

    public GameObject insObj;
    DataDisplayer dataDisplayer;
    refrigerater refriger;

    [Header ("신선도 최고값 최저값")]
    [SerializeField] float k = 0;
    [SerializeField] float y;

    [Header ("신선도 인덱스")]
    public int indexH;
    public int indexL;

    [Header ("부모오브젝트")]
    public string a;


    
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        itemimage = gameObject.transform.GetChild(0).GetComponent<Image>();
        SetTextImage();
        dataDisplayer = GameObject.FindObjectOfType<DataDisplayer>();
        refriger = GameObject.FindObjectOfType<refrigerater>();
    }

    //*아이탬획득 
    public void AddItem(GameObject obj, float fresh)
    {
        SetTextImage();
        Obj = obj;
        item = obj.GetComponent<Info>().item;
        itmeCount = 1;
        itemimage.sprite = item.image;
        text.text = item.name;
        freshness.Add(fresh);
        


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
        FindValue();
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
        SetTextImage();
        FindValue();
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
        a = this.transform.parent.transform.parent.transform.name;
        if(a.Contains("Box"))
        {
            Box(eventData);
        }
        else if(a.Contains("refriger"))
        {
            Refriger(eventData);
        }
        FindValue();
    }

    void Refriger(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            if(item != null)
            {
                if(item.itemType == Ingredient.ItemType.LiveThings)
                {
                    //! 생물일경우
                    Debug.Log(item.name +" 을 사용했습니다.");
                    GameObject G = item.prefab;
                    Instantiate(G, insObj.transform.position, Quaternion.identity);
                    item.prefab.GetComponent<SpriteRenderer>().sortingOrder = 2;
                    G.GetComponent<FoodInfo>().freshness = freshness[indexH];
                    freshness.Remove(freshness[indexH]);

                    //item.prefab.gameObject.GetComponent<FoodInfo>().freshness = freshness.Dequeue();
                }
                else if (item.itemType == Ingredient.ItemType.vegetable)
                {
                    Debug.Log(item.name +" 을 사용했습니다.");
                    GameObject G = item.prefab;
                    Instantiate(item.prefab, insObj.transform.position, Quaternion.identity);
                    item.prefab.GetComponent<SpriteRenderer>().sortingOrder = 2;
                    G.GetComponent<FoodInfo>().freshness = freshness[indexH];
                    freshness.Remove(freshness[indexH]);
                    //item.prefab.gameObject.GetComponent<FoodInfo>().freshness = freshness.Dequeue();
                    SetSlotCount(-1);
                }
            }
        }
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            FindValue();
            dataDisplayer.Display(Obj, k, y, this.gameObject);
        }
    }

    void Box(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            dataDisplayer.Display(Obj, k, y, this.gameObject);
        }
    }
    public void HighValueMoveRef()
    {
        HighValueReturn();
        SetSlotCount(-1);
    }
    public void LowValueReturnRef()
    {
        LowValueReturn();
        SetSlotCount(-1);
    }

    void FindFreshnessValueH()
    {
        k = 0;
        for(int h=0; h < freshness.Count; h++)
        {
            if(freshness[h] > k)
            {
                k = freshness[h];
                indexH = h;
            }
        }
        Debug.Log("k의 인덱스번호는 =" + indexH);
        
        
    }
    void FindFreshnessValueR()
    {
        y = 100;

        for(int l=0; l < freshness.Count; l++)
        {
            if(freshness[l] < y)
            {
                y= freshness[l];
                indexL = l;
            }
        }
        Debug.Log("y의 인덱스번호는 =" + indexL);
        
    }
    void FindValue()
    {
        FindFreshnessValueH();
        FindFreshnessValueR();
    }

    public void HighValueReturn()
    {
        Debug.Log("하이벨류");
        refriger.AcquireItem(Obj, freshness[indexH]);
        freshness.Remove(freshness[indexH]);
        
    }
    public void LowValueReturn()
    {
        refriger.AcquireItem(Obj, freshness[indexL]);
        freshness.Remove(freshness[indexL]);
    }




}
