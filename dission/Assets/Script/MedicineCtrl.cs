using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineCtrl : MonoBehaviour
{
    public GameObject mediObj;

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
            //print(mediObj.tag + "채집완료!");

            Destroy(mediObj);

        }
    }
}
