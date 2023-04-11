using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[CreateAssetMenu(fileName = "Ingredient", menuName = "Ingredient/ ingredient", order = int.MinValue)]

public class Ingredient : ScriptableObject
{
    public string ingredientName;

    public Sprite image;
    public Sprite[] loadImgae;
    public ItemType itemType;
    public GameObject prefab;

    [TextArea]    public string description;
    public enum ItemType
    {
        Souce,
        vegetable,
        LiveThings
    }
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
