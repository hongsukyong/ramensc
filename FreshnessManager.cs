using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreshnessManager : MonoBehaviour
{

    [SerializeField] List<float> freshness = new List<float>();
    [SerializeField] List<GameObject> foodInfos = new List<GameObject>();
    int i;
    float x;
    /*
    Queue<float> freshness = new Queue<float>();
    int i;
    
    public void EnQueue( )
    {
        
        freshness.Enqueue(i); //! 큐 넣기
    }
    public float DeQueue()
    {
        return freshness.Dequeue(); //!큐 빼기 (처음들어간 데이터가 나옴)
    }
    public float Peek()
    {
        return freshness.Peek(); //!맨앞의 데이터 가져오기
    }

    public float Count()
    {
        return freshness.Count; //!큐 길이 가져오기
    }
    */

    void Start()
    {

    }
    void FixedUpdate()
    {
        DecreaseFloat();
        
    }
    void DecreaseFloat()
    {
        x += Time.deltaTime * 0.03f;
    }

    void FreshnessDecrease() //! 아이템을 꺼내거나 동작이 될 때 사용?
    {
        for(int i =0; freshness.Count > i; i++)
        {
            freshness[i] -= x;
            foodInfos[i].GetComponent<FoodInfo>().freshness = freshness[i];
        }
    }

    public void AddList(GameObject a)
    {
        float x = a.GetComponent<FoodInfo>().freshness;
        freshness.Add(x);
        foodInfos.Add(a);
        ListNumbering();
        a.GetComponent<FoodInfo>().listNum = i;
    }
    void ListNumbering()
    {
        int i = freshness.Count;
    }
}
