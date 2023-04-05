using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventortManager : MonoBehaviour
{
    [SerializeField] refrigerater refScript;
    [SerializeField] BoxScript box;
    public List<Ingredient> liveThing = new List<Ingredient>();
    public List<Ingredient> vegetable = new List<Ingredient>();
    public List<Ingredient> souce = new List<Ingredient>();
    float a;

    

    void Start()
    {
        refScript = GameObject.FindObjectOfType<refrigerater>();
        box = GameObject.FindObjectOfType<BoxScript>();
    }
    
    public void AddBox(GameObject item)
    {
        float a = item.GetComponent<FoodInfo>().freshness;
        box.AcquireItem(item, a);
    }
    public void AddItem(GameObject x)
    {
        AddBox(x);
    }

}
