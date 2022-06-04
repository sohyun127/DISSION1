using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{

    Dictionary<int, string[]> talkData;
   Dictionary<int, string[]> nameData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
       nameData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1, new string[] { "�ȳ� ���� ��Ҽ� ��������� ��", "�� ���� ó�� �Ա���?" });
        talkData.Add(2, new string[] { "�ȳ� ���� ������ �Բ� �����̶�� ��" });
        nameData.Add(1, new string[] { "��Ҽ� ������" });
       nameData.Add(2, new string[] {"������ �Բ� ����"});
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
        return talkData[id][talkIndex];
    }

   public string GetName(int id,int nameIndex)
    {
       return nameData[id][nameIndex];
    }
}
