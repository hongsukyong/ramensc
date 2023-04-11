using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoppiingBoard : MonoBehaviour
{
    public GameObject currentDoma;
    public Camera cam;
    Vector3 eventPos;
    Vector3 originPos;
    [SerializeField] Canvas eventcanvas;
    [SerializeField] Image slider;
    public int speed;
    [SerializeField] GameObject pnael;
    [SerializeField] TextMeshProUGUI text;
    public GameObject actionP;
    DragManager dragManager1;
    [SerializeField] DomaEvent domaEvent;
    [SerializeField] Sprite domaimg;
    [SerializeField] GameObject DOmaImageP;
    void Start()
    {

        dragManager1 = GameObject.FindObjectOfType<DragManager>();
        originPos = cam.transform.position;
        eventPos = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y , -10);
        eventcanvas.gameObject.SetActive(false);
        slider.fillAmount = 0f;
        currentDoma = GameObject.FindObjectOfType<DomaInfo>().gameObject;
    }
    public void ChopboardOpen()
    {
        if(dragManager1.controllObj != null)
        {
            eventcanvas.gameObject.SetActive(true);
            TextControll();
            domaEvent.gameObject.SetActive(false);
            domaimg = currentDoma.GetComponent<DomaInfo>().doma.image;
            DOmaImageP.GetComponent<Image>().sprite = domaimg; //? 도마의 픽셀사이즈가 달라서 화면 ui가 도마크기를 따라 이동함 도마크기 통일할 필요 있음 
        }
    }

    void Update()
    {
        SliderDecrease();
        CanvasOnOff();
    }

    void SliderDecrease()
    {
       if(slider.gameObject.activeSelf)
       {
            slider.fillAmount -= Time.deltaTime /speed;
            domaEvent.aciontIng = true;

            if(slider.fillAmount == 0)
            {
                SliderOver();
            }
       }
    }
    void SliderOver()
    {
        domaEvent.aciontIng =false;
        slider.gameObject.SetActive(false);
        domaEvent.ResultDomaEvent();
    }

    public void SliderOpen()
    {
        slider.gameObject.SetActive(!slider.gameObject.activeSelf);
        slider.fillAmount = 1f;
    }

    void DomaEvent()
    {
        pnael.gameObject.SetActive(!pnael.gameObject.activeSelf);
    }

    void TextControll()
    {
        DragManager dragManager;
        dragManager = FindObjectOfType<DragManager>();
        
        text.text = dragManager.controllObj + "를 손질하겠습니까?";
    }

    void CanvasOnOff()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            eventcanvas.gameObject.SetActive(false);
        }
    }

    public void PanelOpen()
    {
        actionP.gameObject.SetActive(true);
        SliderOpen();
    }

    #region  미식괴식 선택버튼

    public void GourmetFood()
    {
        dragManager1.controllObj.GetComponent<FoodInfo>().미식 += domaEvent.미식력;
        EndEvent();
    }
    public void StrangeFood()
    {
        dragManager1.controllObj.GetComponent<FoodInfo>().괴식 += domaEvent.괴식력;
        EndEvent();
    }

    void EndEvent()
    {
        eventcanvas.gameObject.SetActive(false);
        actionP.gameObject.SetActive(false);
        domaEvent.FigureReset();
    }

    #endregion
    

}
