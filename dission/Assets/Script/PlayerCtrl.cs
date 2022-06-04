using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl: MonoBehaviour
{
    // [ 플레이어 hp ]
    protected static int hp = 100;
    // 약초 얻었을 때 => hp 100으로 

    // [ 허기 게이지 ]
    protected static int hungry = 100;
    float hungryTime = 10; // 10초 마다 허기게이지 1씩 감소 => 약 15분 후 허기0
    public GameObject Quest;
    public bool isAction = false;
    public Text talkText;
    public Text nameText;
    public TalkManager talkManager;
    public int talkIndex;
    public int nameIndex;

    //------------- 임시로 캐릭터 움직임 구현 (추후 삭제) -------------
    public float speed = 5f;
    public LayerMask layermask;

    void Update()
    {
        hungryTime -= Time.deltaTime;

        if (hungryTime < 0 )
        {
            hungry -= 1;
            print("허기게이지 1 감소  hungry=" + hungry);
            hungryTime = 10; // 다시 시작
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }

        Quest.SetActive(false);

        FireRay();

    }
    //------------- ------------------------------ -------------


    void FireRay()
    {
        RaycastHit hitInfo; 

        if(Physics.Raycast(this.transform.position, this.transform.forward,out hitInfo,5f,layermask))
        {
            if (isAction)
            {
                Quest.SetActive(true);
            }
            
            if(Input.GetKeyDown(KeyCode.Q))
            {
                
                    isAction = true;
                    GameObject obj = hitInfo.transform.gameObject;
                    Objdata objData = obj.GetComponent<Objdata>();
                    Talk(objData.id);
            

            }
        }
    }

    void Talk(int id)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);
        string nameData=talkManager.GetName(id,nameIndex);
        if (talkData==null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }
        talkText.text = talkData;
        nameText.text = nameData;
        talkIndex++;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Animals") // 동물과 충돌
        {
            hp -= 5;  // 플레이어의 hp감소 

            print("동물에게 데미지를 얻었습니다."+ hp);
        }
    }


}
