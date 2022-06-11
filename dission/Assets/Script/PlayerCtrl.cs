using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCtrl: MonoBehaviour
{
    
    protected static int hp = 100;  
    protected static int hungry = 100; 
    float hungryTime = 10; // 10�� ���� �������� 1���� => �� 15�� �� ��� 0
    public GameObject Quest;
    public bool isAction = false;
    public Text talkText;
    public Text nameText;
    public TalkManager talkManager;
    public int talkIndex;
    public int nameIndex;

    public GameObject hpGauge;
    public GameObject hungryGauge;

    public LayerMask layermask;
    private Animator animator;
    public bool isAttack = false;
    public int foodCount = 0;
    public int medicineCount = 0;

    void Update()
    {
        // ������ ������Ʈ
        this.hungryGauge.GetComponent<Image>().fillAmount = hungry / 100f;
        this.hpGauge.GetComponent<Image>().fillAmount = hp / 100f;

        hungryTime -= Time.deltaTime;

        if (hungryTime < 0 )
        {
            hungry -= 1;

            hungryTime = 10; // �ٽ� ����
        }
        
        Quest.SetActive(false);

        FireRay();

        if (hp <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }


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
        }

        if(gameObject.tag == "Food")
        {
            foodCount++;

            //hungry = 100;
        }

        if (gameObject.tag == "Medicine")
        {
            medicineCount++;

            //hp = 100;
        }

    }


}
