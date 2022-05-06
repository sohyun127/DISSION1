using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    public GameObject monObj;
    int hp;

    // Start is called before the first frame update
    void Start()
    {
        if(monObj.tag == "Monster1") // ���� ü�� 10
        {
            hp = 10;
        }
        else if (monObj.tag == "Monster2") // ���� ü�� 20
        {
            hp = 20;
        }
        else if (monObj.tag == "Monster3") // ���� ü�� 30
        {
            hp = 30;
        }
    }

    void Update()
    {
        if( hp <= 0 ) // ���� ü���� 0 ���ϰ� �Ǹ�
        {
            // ���� ����
            Destroy(monObj, 1); // 1�� �ڿ� ����� -> ���� �ִϸ��̼� ������ ���� ��Ű�� �ð�

        }
    }
    
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Weapon") // ����� �浹 ��
        {
            print(monObj.tag+"�� ������ ����");

            hp -= 10;
            
        }
    }
    
}
