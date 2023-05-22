using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stemina : MonoBehaviour
{
    public int st;
    TimeManager time;
    public void Start()
    {
        time = GetComponent<TimeManager>();
        st = 10;
    }
    public void SteminaDown()
    {
        time.StDown(st);
    }
}
