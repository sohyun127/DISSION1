using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl: MonoBehaviour
{
    // [ �÷��̾� hp ]
    int hp = 100; 
    // ���� ����� �� => hp 100���� 

    // [ ��� ������ ]
    int hungry = 100; 
    float hungryTime = 10; // 10�� ���� �������� 1�� ���� => �� 15�� �� ���0

    //------------- �ӽ÷� ĳ���� ������ ���� (���� ����) -------------
    //public float speed = 5f;

    void Update()
    {
        hungryTime -= Time.deltaTime;

        if (hungryTime < 0 )
        {
            hungry -= 1;
            print("�������� 1 ����");
            hungryTime = 10; // �ٽ� ����
        }
    }

    //------------- ------------------------------ -------------
    
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Animals") // ������ �浹
        {
            print("�������� �������� ������ϴ�.");

            hp -= 5;  // �÷��̾��� hp���� 
            print(hp);
        }
    }
    
    private void OnTriggerEnter(Collider col)
    {
        // �κ��丮 ���� �� �ٽ� ����!!!!!!!!!!
        if (col.tag == "Item") //������ ����
        {
            print("���� ȹ��");
            Destroy(col.gameObject);
            // hp = 100;  // �÷��̾��� hp����
        }
    }
    
}
