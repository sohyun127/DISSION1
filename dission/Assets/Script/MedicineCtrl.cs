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
        if (col.gameObject.tag == "Weapon") // ����� �浹 ��
        {
            //print(mediObj.tag + "ä���Ϸ�!");

            Destroy(mediObj);

        }
    }
}
