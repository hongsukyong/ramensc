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
    void Start()
    {
        itemName.text = "";
        description.text = "";
        image.sprite = null;
        panel.gameObject.SetActive(false);
    }

    public void Display(GameObject item)
    {
        Ingredient _item = item.GetComponent<Info>().item;
        panel.gameObject.SetActive(true);
        itemName.text = _item.ingredientName;
        image.sprite = _item.image;
        description.text = _item.description + System.Environment.NewLine + "가장신선함 : " + "" + System.Environment.NewLine + "가장 상태가 좋지않은 것 :" + "";
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

}
