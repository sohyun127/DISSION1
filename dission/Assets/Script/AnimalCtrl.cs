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
        if (col.gameObject.tag == "Weapon") // ����� �浹 ��
        {
            print(aniObj.tag + "��� �Ϸ�");
            Destroy(aniObj, 1);
            // ������ ��� �����ϱ�!!

            //Vector3 v = new Vector3(0f, -1f, 1f);
            //Item.position = col.transform.position + v;
            //SrartCoroutine("dropTheItems"); // �ڷ�ƾ ���


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
