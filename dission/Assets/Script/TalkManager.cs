using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{

    Dictionary<int, string[]> talkData;
   Dictionary<int, string[]> nameData;

    private Level level;
    int count = 0;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
       nameData = new Dictionary<int, string[]>();
        GenerateData();

        level = GameObject.Find("Player").GetComponent<Level>();
    }

    void GenerateData()
    {
        talkData.Add(1, new string[] { "�ȳ� ���� ��Ҽ� ��������� ��.", "�� ���� ó�� �Ա���?","�׷� ���ݺ��� ���� ���۹��� �˷��ٰ�.","W A S D Ű�� ������ �� �� �� ��� �̵��� �����ϰ�"+" ���� �����̽��ٸ� ������ ������ ������.","NPC ������ ���� QŰ�� ������ NPC�� ��ȭ�� �� �� �־�." ,
                                        "���� ������ �Բ� �����̶�� NPC�� ã�Ƽ� ���� �ɾ��."});
        talkData.Add(2, new string[] { "�ȳ� ���� ������ �Բ� �����̶�� ��" });

        nameData.Add(1, new string[] { "��Ҽ� ������" });
       nameData.Add(2, new string[] {"������ �Բ� ����"});
    }


    void Update()
    {
        if(level.levelData==0 && count>0)
        {
            level.levelData = 1;
        }



    }
    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            talkData.Remove(id);
            if(id==1)
            {
                talkData.Add(1, new string[] { "�ȳ� ���� ��Ҽ� ��������� ��." });
            }
            else if(id==2)
            {
                talkData.Add(2, new string[] { "�ȳ� ���� ������ �Բ� �����̶�� ��" });
                count++;
            }
            return null;
        }
        else
        return talkData[id][talkIndex];
    }

   public string GetName(int id,int nameIndex)
    {
       return nameData[id][nameIndex];
    }
}
