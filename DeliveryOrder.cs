using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryOrder : MonoBehaviour
{
    [SerializeField] GameObject p_Panel;
    public refrigerater refriger;
    public GameObject slot1;
    InventortManager inventortManager;
    FreshnessManager freshnessManager;
    ItemDatabase itemDb;

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

    public void OrderItem()
    {
        int i = Random.Range(0, itemDb.ingredientItme.Count);
        GameObject x = itemDb.ingredientItme[i];
        Instantiate(x,itemDb.transform,true);
        x.transform.position = itemDb.transform.position;

        //Ingredient a = x.GetComponent<Ingredient>();
        inventortManager.AddItem(x);
        freshnessManager.AddList(x);
        //Debug.Log(a + "인벤토리 목록으로 추가되었습니다");
        
    }

    public void SpawnEvent()
{
	int i = ranom.range(0,9);
	GameObject A;

	for(int b= 0; b <i; b++);
	{
		ItemDraw();
		inventoryManager.AddItem(A);
	}
}

void ItemDraw()
{
	int x = Random.Range(0, itemDb.ingredientItem.Count);
	GameObject A = itemDB.ingredientItem[x];
	SpawnItem(A);
	FreshnessDraw(A);
}

void SpawnItem(GameObject A)
{
	Instantiate(A, itemDb.transform, true);
	A.transform.position = ItemDb.transform.position;	
}

void FreshnessDraw(GameObject x, Int y) //int y 는 상점의 등급 10등급까지 있을예정
{

	int k = Random.Range( 10 * y + 1, 100);
	x.foodinfo.freshness = k;
}

}
