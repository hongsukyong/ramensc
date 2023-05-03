using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

[CreateAssetMenu(fileName = "potImg", menuName = "img", order = 0)]
public class Potsprite : ScriptableObject
{
    public Sprite img;
    public int spriteNum;
}
