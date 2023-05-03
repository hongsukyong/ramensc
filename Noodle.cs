using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noodle : MonoBehaviour
{
    public GameObject noodle_p;
    public GameObject soup_p;
    public GameObject slotP;
    public GameObject nomalNoodle;
    public GameObject nomalSoup;

    public void SelectNoodle()
    {
        Instantiate(nomalNoodle, noodle_p.transform.position, Quaternion.identity);
    }
    public void SelectSoup()
    {
        Instantiate(nomalSoup, soup_p.transform.position, Quaternion.identity);
    }
    //! 진행상황에 관하여 - 면과 스프를 따로넣는 진행과 라면 하나를 까서 넣는 진행을 나누고 싶음 /
    //! 해야하는 방법은 ? 

}
