using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCtrl : MonoBehaviour
{
    //public GameObject Animal;
    //public GameObject Item;
    public GameObject aniObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Weapon") // 무기와 충돌 시
        {
            print(aniObj.tag + "사냥 완료");
            Destroy(aniObj, 1);
            // 아이템 드랍 구현하기!!

            //Vector3 v = new Vector3(0f, -1f, 1f);
            //Item.position = col.transform.position + v;
            //SrartCoroutine("dropTheItems"); // 코루틴 사용


        }
    }
    /*
    IEnumerator dropTheItems()
    {
        yield return new WaitForSeconds(0.3f);
        for(int i=0; i<maxItems; i++)
        {
            Instantiate(Beet, Animal.position, Quaternion.identity);
        }
    }
    */
}
