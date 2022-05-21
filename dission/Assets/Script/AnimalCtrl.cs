using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCtrl : MonoBehaviour
{
    //public GameObject Animal;
    //public GameObject Item;
    public GameObject aniObj;
    private Rigidbody ani;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveObject());
    }
    IEnumerator MoveObject()
    {
        ani = GetComponent<Rigidbody>();

        while(true)
        {
            float dir1 = Random.Range(-1.5f, 1.5f);
            float dir2 = Random.Range(-1.5f, 1.5f);

            yield return new WaitForSeconds(2);
            //ani.velocity = direction * 10 * Time.fixedDeltaTime;
            ani.velocity = new Vector3(dir1, 3, dir2);
        }
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
