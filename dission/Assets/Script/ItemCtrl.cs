using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : PlayerCtrl // �κ��丮 �ϸ� ��� �����ϱ�
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 360f, 0), Time.deltaTime * 45, Space.World);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player") // �÷��̾�� �浹 ��
        {

            // (�κ��丮 ����)  �κ��丮 ���� �� ����

            if (gameObject.tag == "Food")
            {                
                hungry = 100; // ��� ������ �������� ä���
                print("���� ȹ�� hungry=" + hungry);
            }
            else if (gameObject.tag == "Medicine")
            {
                hp = 100; // hp ������ �������� ä���
                print("���� ȹ�� hp="+hp);
            }

            // ����
            Destroy(gameObject);

        }

        
    }
}
