using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl: MonoBehaviour
{
    // [ �÷��̾� hp ]
    protected static int hp = 100;
    // ���� ����� �� => hp 100���� 

    // [ ��� ������ ]
    protected static int hungry = 100;
    float hungryTime = 10; // 10�� ���� �������� 1�� ���� => �� 15�� �� ���0
    public GameObject Quest;
    public bool isAction = false;
    public Text talkText;
    public Text nameText;
    public TalkManager talkManager;
    public int talkIndex;
    public int nameIndex;

    //------------- �ӽ÷� ĳ���� ������ ���� (���� ����) -------------
    public float speed = 5f;
    public LayerMask layermask;

    void Update()
    {
        hungryTime -= Time.deltaTime;

        if (hungryTime < 0 )
        {
            hungry -= 1;
            print("�������� 1 ����  hungry=" + hungry);
            hungryTime = 10; // �ٽ� ����
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
        if (col.gameObject.tag == "Animals") // ������ �浹
        {
            hp -= 5;  // �÷��̾��� hp���� 

            print("�������� �������� ������ϴ�."+ hp);
        }
    }


}
