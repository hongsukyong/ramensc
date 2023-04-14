using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveDb : MonoBehaviour
{
    public List<Ingredient> inputItems = new List<Ingredient>();

    public List<Ingredient> returnItems = new List<Ingredient>();
    public Ingredient returnItem;
    public GameObject inputItem;
    DragManager dragManager;

    public void DataInput(GameObject _g)
    {
        if(_g.gameObject.GetComponent<Info>().item.fry)
        {
            Ingredient ing = _g.GetComponent<Info>().item;
            inputItem = _g;

            for (int i = 0; i < inputItems.Count; i++)
            {
                Debug.Log("i =" + i);
                if (ing == inputItems[i])
                {

                    Debug.Log(inputItems[i]);
                    returnItem = returnItems[i];
                    return;
                }
            }

        }
    }
}
