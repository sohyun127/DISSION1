using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl: MonoBehaviour
{
    // �÷��̾� ������ ��ġ�鼭 �߷� üũ �ؾ���

    int hp = 100; // �÷��̾��� hp ������

    // ���� ����� �� => hp 100���� 


    int hungry = 100; // ��� ������

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
        /*
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
        }*/
    }
    //------------- ------------------------------ -------------
   
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Monster1") //����1�� �浹 ��
        {
            print("����1�� �浹");

            hp -= 2;  // �÷��̾��� hp���� : -2 ����

        }
        else if (col.gameObject.tag == "Monster2") //����2
        {
            print("����2�� �浹");

            hp -= 5; // �÷��̾��� hp���� : -5 ����

        }
        else if (col.gameObject.tag == "Monster3") //����3
        {
            //print("���Ϳ� �浹");

            hp -= 8;  // �÷��̾��� hp���� : -8 ����

        }
    }
    
}
