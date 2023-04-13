using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[CreateAssetMenu(fileName = "Pot", menuName = "Item/ Pot", order = int.MinValue)]
public class Pot : ScriptableObject
{
    public string itemName;
    public Sprite image;
    public GameObject prefab;
    public Sprite[] loadImgae;
    public float 총내구도;

    public enum ItemGrade
    {
        Comon,
        Nomal,
        Rare,
        Epic,
        Legend,
        Hidden
    }

}