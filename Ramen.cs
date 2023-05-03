using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Ramen", menuName = "Item/Ramen", order = int.MinValue)]

public class Ramen : ScriptableObject
{
    public string ramenName;

    public Sprite image;
    public Sprite[] loadImgae;
    public ItemType itemType;
    public GameObject prefab;
    public int itemNumber;

    [TextArea] public string description;
    public enum ItemType
    {
        
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
