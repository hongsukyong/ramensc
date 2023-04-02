using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[CreateAssetMenu(fileName = "Ingredient", menuName = "Ingredient/ ingredient", order = int.MinValue)]

public class Ingredient : ScriptableObject
{
    public string ingredientName;

    public Sprite image;

    public ItemType itemType;
    public GameObject prefab;

    [TextArea]    public string description;
    public enum ItemType
    {
        Souce,
        vegetable,
        LiveThings
    }
}
