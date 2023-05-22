using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public int day;
    public float time;
    public float min;
    public int sec;
    public float secIncreaser;
    public TextMeshProUGUI text;

    void Start()
    {
        sec = 1;
        min = 0;
        time = 0;
    }

    void TimeFlow()
    {
        secIncreaser += Time.deltaTime;
        
        if(secIncreaser >= sec )
        {
            sec++;
        }

        if(sec >= 60)
        {
            sec = 0;
            min++;
        }
        if(min >= 60)
        {
            min = 0;
            time++;
        }
        if(time >= 24)
        {
            time = 0;
            day++;
        }
    }

    void Update()
    {
        TimeFlow();
        text.text = time.ToString() + " : " + min.ToString();
    }
    void SetMorning()
    {

    }
    void SetOpen()
    {

    }
    void SetClose()
    {

    }
    public void StDown(int A)
    {
        A--;
    }
}
