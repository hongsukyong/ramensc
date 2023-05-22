using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public List<GameObject> spriteList = new List<GameObject>();
    public enum spriteParts {head = 0, nose = 1, mouse = 2, eye = 3};
    public bool isOn;

    public void IsOn()
    {
        isOn = true;
    }
    
}
