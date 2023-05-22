using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    /*
        ! 손님 스포너 할일 
        todo 손님을 소환하기 위한 오브젝트에 들어가는 컴포넌트 
        todo 손님마다 랜덤한 취향과 아이탬 드랍율을 가져야 함
        todo 손님이 없어지고 생기는  방식을 구현해야함 
        손님의 spawn 과 destroy 는 시간과 스테미너에 연결이 되야 함
        손님과 이벤트가 성공이든 실패든 손님이 사라지면 스태미너에 영향을 줄 것이고
        손님의 스폰은 영업중 이라는 상태효과가 있을 시에만 작동해야됨 손님의 스폰은 코루틴을 사용하는 것 또한 나쁘지 않아보임
        손님이 스폰되면서 랜덤값이 손님에 적용되는데 빈 오브젝트를 만들어서 슬롯처럼 컴포넌트를 각각 적용하고 
        스포는 손님오브젝트를 배열로 관리하는 방법을 쓰면 괜찮을것 같음
        손님은 mob이라는 태그로 관리하기 
        스폰으로 일단 구현할 과제들
        손님이라는 배열을 만들어서 오브젝트의 이미지를 변경해서 손님이 등장하는 것처럼 만든다!
        ! 스프라이트배열을 만들어서 손님에 적용하기 
        슬롯에 있는 게임오브젝트안에 스프라이트를 적용할 네가지 빈 오브젝트가 필요함 슬롯에 스프라이트 배열을 만들어서 스프라이트 배열  추출해서 각각이미지 적용하는 방식으로 하면 좋을듯
         


    */ 
    
    public List<GameObject> mobs = new List<GameObject>();
    public List<Sprite> heads = new List<Sprite>();
    public List<Sprite> noses = new List<Sprite>();
    public List<Sprite>  mouses = new List<Sprite>();
    public List<Sprite> eyes = new List<Sprite>();
    public const int head = 1, nose =2, mouse = 3, eye = 4;
    GameObject G;
    SpriteRenderer A;
    public TimeManager time;
    
    void Start()
    {
    }
 
    void SpawnSysStart()
    {
        
        if(time.sec % 5 == 0)
        {
            Debug.Log("1");
            time.sec++;
            SpawnCondition();
        } 
        
    }
    void SpawnCondition()
    {
        int i = Random.Range(0,10);

        if(i > 4)
        {
            Spawn();
        }
            
    }
    void FixedUpdate()
    {
        SpawnSysStart();
    }

    void Spawn() //! 스폰이 생기는 조건 만들기 
    {
        Debug.Log("spawn");
        RandomInt();
        MakeSprite();
        //! 적랜덤으로 몹을 선택하는 메소드랑 랜덤으로 이미지를 적용하는 메소드 필요
    }

    void RandomInt() 
    {
        int i = Random.Range(0,3); //? 스폰하는 슬롯을 결정하기 위한 정수값
        Debug.Log(i);
        G = mobs[i];
        //G.GetComponent<Mob>().IsOn();
        ConfirmSlotNull();
    }
    void ConfirmSlotNull()
    {
        if(G.GetComponent<Mob>().isOn)
        {
            RandomInt();
        }
        else 
        {
            return;
        }
    }

    void MakeSprite()
    {
        HeadDesing();
        NoseDesing();
        MouseDesing();
        //EyeDesing();
    }
    void HeadDesing()
    {
        Direct(0);
        int b = Random.Range(0, heads.Count);
        A.sprite = heads[b];
    }
    void NoseDesing()
    {
        Direct(1);
        int b = Random.Range(0, noses.Count);
        A.sprite = noses[b];
    }
    void MouseDesing()
    {
        Direct(2);
        int b = Random.Range(0, mouses.Count);
        A.sprite = mouses[b];
    }
    void EyeDesing()
    {
        Direct(3);
        int b = Random.Range(0, eyes.Count);
        A.sprite = eyes[b];
    }

    void Direct(int count)
    {
        A = G.GetComponent<Mob>().spriteList[count].GetComponent<SpriteRenderer>();
    }
}
