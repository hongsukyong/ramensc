using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DomaEvent : MonoBehaviour
{
    public Image A;
    public Image D;
    bool isA;
    int stack = 0;
    TextMeshProUGUI text;
    public bool aciontIng;
    public int 미식력;
    public int 괴식력;
    [SerializeField] GameObject panel;
    [SerializeField] TextMeshProUGUI panelText;


    
    void Start()
    {
        panel.SetActive(false);
        text= GetComponentInChildren<TextMeshProUGUI>();
        
    }
    void BuottnInput()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            True();
            ColorSetUp(A, true);
        }
        else if(Input.GetKeyUp(KeyCode.A))
        {
            ColorSetUp(A, false);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            Stacking();
            ColorSetUp(D, true);
        }
        else if(Input.GetKeyUp(KeyCode.D))
        {
            ColorSetUp(D, false);
        }
 

    }
 

    void Update()
    {
        text.text = stack.ToString();
        BuottnInput();
    }

    
    public void True()
    {
        if(aciontIng)
        isA = true;
    }
    public void Stacking()
    {
        if(isA)
        {
            AddStack();
        }
        isA = false;
    }

    void AddStack()
    {
        stack++;
        int x = Random.Range(0,9); //! 0과 9 는 '임의'의 숫자 플레이어의 컨디션에 따라 변동가능한 변수를 넣을 예정
        if(x < 5)       //!마찬가지로 숫자5도 default, 아이템에 따라서 미식력 괴식력의 차이가 생길것
        {
            미식력++;
        }
        else
        {
            괴식력++;
        }
    }

    public void ResultDomaEvent()
    {
        string result;
        if(미식력 > 괴식력)
        {
            result = "미식의 길에 가까운 음식인거같습니다";
        }
        else
        {
            result = "괴식의 길에 가까운 음식입니다";
        }

        aciontIng =false;
        panel.gameObject.SetActive(true);
        panelText.text = result;
    }
    public void FigureReset()
    {
        미식력 = 0;
        괴식력 = 0;
        stack  = 0;
    }
    void ColorSetUp(Image X, bool z)
    {
        if(z)
        {
            X.GetComponent<Image>().color = new Color32(100,100,100,255);
        }
        else
        {
            X.GetComponent<Image>().color = new Color32(255,255,255,100);
        }
    }



}
