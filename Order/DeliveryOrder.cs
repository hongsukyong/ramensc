using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryOrder : MonoBehaviour
{
    public GameObject p_Panel;
    public refrigerater refriger;
    public GameObject slot1;
    InventortManager inventortManager;
    FreshnessManager freshnessManager;
    ItemDatabase itemDb;
    GameObject A;

    void Start()
    {
        inventortManager = GameObject.FindObjectOfType<InventortManager>();
        freshnessManager = GameObject.FindObjectOfType<FreshnessManager>();
        itemDb = GameObject.FindObjectOfType<ItemDatabase>();
    }
    public void PanelOpen()
    {
        p_Panel.SetActive(!p_Panel.activeSelf);
    }

    public void SpawnEvent()
{
	int i = Random.Range(0,9);
    InventortManager inventortManager = FindObjectOfType<InventortManager>();

	for(int b= 0; b <i; b++)
	{
        int x = Random.Range(0, itemDb.ingredientItem.Count);
	    GameObject A = itemDb.ingredientItem[x];
		ItemDraw(A);
	}
    p_Panel.SetActive(false);
}

void ItemDraw(GameObject A)
{
	//SpawnItem(A);
	FreshnessDraw(A, 1);
    inventortManager.AddItem(A);
}

void SpawnItem(GameObject A)
{
	Instantiate(A, itemDb.transform, true);
	A.transform.position = itemDb.transform.position;	
}

void FreshnessDraw(GameObject x, int y) //int y 는 상점의 등급 10등급까지 있을예정
{

	int k = Random.Range( 10 * y + 1, 100);
	x.GetComponent<FoodInfo>().freshness = k;
}




//Todo : 상점등급 만들기


}
