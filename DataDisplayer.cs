using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DataDisplayer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI description;
    public GameObject panel;
    public bool isOn;
    [SerializeField] float x;
    [SerializeField] float y;
    [Header ("현제 아이템 슬롯")]
    [SerializeField] GameObject currentSlot;
    void Start()
    {
        itemName.text = "";
        description.text = "";
        image.sprite = null;
        panel.gameObject.SetActive(false);
    }

    public void Display(GameObject item, float x, float y, GameObject S)//? x 는 높은 신선도//? y 는 낮은신선도
    {
        currentSlot = S;
        Ingredient _item = item.GetComponent<Info>().item;
        panel.gameObject.SetActive(true);
        itemName.text = _item.ingredientName;
        image.sprite = _item.image;
        description.text = _item.description + System.Environment.NewLine + "높은신선도 : " + x + System.Environment.NewLine + "낮은신선도 : " + y ; 

        OnOff();
    }

    public void DisplayOff()
    {
        panel.gameObject.SetActive(false);
        OnOff();
    }

    public void OnOff()
    {
        isOn = panel.gameObject.activeSelf;
    }

    public void HighValue()     //? 신선도 높은거 가져오기  //?박스랑 냉장고에 차별을 둬야함 
    {
        Debug.Log("디스플레이 하이벨류");
        currentSlot.GetComponent<refSlot>().HighValueMoveRef();
        DisplayOff();
    }
    public void LowValue()
    {
        currentSlot.GetComponent<refSlot>().LowValueReturn();
        DisplayOff();
    }

    

}
