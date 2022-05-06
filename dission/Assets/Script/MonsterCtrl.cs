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
        if(monObj.tag == "Monster1") // 몬스터 체력 10
        {
            hp = 10;
        }
        else if (monObj.tag == "Monster2") // 몬스터 체력 20
        {
            hp = 20;
        }
        else if (monObj.tag == "Monster3") // 몬스터 체력 30
        {
            hp = 30;
        }
    }

    void Update()
    {
        if( hp <= 0 ) // 몬스터 체력이 0 이하가 되면
        {
            // 몬스터 제거
            Destroy(monObj, 1); // 1초 뒤에 사라짐 -> 기절 애니메이션 같은거 실행 시키는 시간

        }
    }
    
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Weapon") // 무기와 충돌 시
        {
            print(monObj.tag+"가 데미지 얻음");

            hp -= 10;
            
        }
    }
    
}
