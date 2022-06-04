using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NewScenePlayer : MonoBehaviour 
{
    // [ �÷��̾� hp ]
    protected static int hp = 100;
    // ���� ����� �� => hp 100���� 

    // [ ��� ������ ]
    protected static int hungry = 100;
    float hungryTime = 10; // 10�� ���� �������� 1�� ���� => �� 15�� �� ���0
    
    public GameObject hpGauge;
    public GameObject hungryGauge;

    //------------- �ӽ÷� ĳ���� ������ ���� (���� ����) -------------
    public float speed = 5f;
   

    void Update()
    {
        hungryTime -= Time.deltaTime;

        if (hungryTime < 0)
        {
            hungry -= 1;
            print("�������� 1 ����  hungry=" + hungry);
            this.hungryGauge.GetComponent<Image>().fillAmount -= 0.01f;
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


    }
    //------------- ------------------------------ -------------

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Animals") // ������ �浹
        {
            hp -= 5;  // �÷��̾��� hp���� 
            this.hpGauge.GetComponent<Image>().fillAmount -= 0.05f;

            print("�������� �������� ������ϴ�." + hp);
        }
    }

}
