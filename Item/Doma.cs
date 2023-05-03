using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[CreateAssetMenu(fileName = "Doma", menuName = "Item/ Doma", order = int.MinValue)]
public class Doma : ScriptableObject
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