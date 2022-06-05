using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{

    Dictionary<int, string[]> talkData;
   Dictionary<int, string[]> nameData;

    private Level level;
    int count = 0;
    int Quest = 0;
    private PlayerCtrl playerctrl;
  
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
       nameData = new Dictionary<int, string[]>();
        GenerateData();

        playerctrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        level = GameObject.Find("Player").GetComponent<Level>();
    }

    void GenerateData()
    {
        talkData.Add(1, new string[] { "�ȳ� ���� ��Ҽ� ��������� ��.", "�� ���� ó�� �Ա���?","�׷� ���ݺ��� ���� ���۹��� �˷��ٰ�.","W A S D Ű�� ������ �� �� �� ��� �̵��� �����ϰ�"+" ���� �����̽��ٸ� ������ ������ ������.","NPC ������ ���� QŰ�� ������ NPC�� ��ȭ�� �� �� �־�." ,
                                        "���� ������ �Բ� �����̶�� NPC�� ã�Ƽ� ���� �ɰ� �ٽ� �����Է� ��."});

        talkData.Add(2, new string[] { "�ȳ� ���� ������ �Բ� �����̶�� ��" });

        talkData.Add(3, new string[] { "�ȳ� ���� ������ �Ӹ���� ��" });


     
        nameData.Add(1, new string[] { "��Ҽ� ������" });
        nameData.Add(2, new string[] {"������ �Բ� ����"});
        nameData.Add(3, new string[] { "������ �Ӹ�" });
    }


    void Update()
    {
        if(level.levelData==0 && count>0)
        {
            level.levelData = 1;
            Quest++;
        }

        if (Quest == 1)
        {
            Quest++;
            talkData.Remove(1);
            talkData.Add(1, new string[] { "���� ������ ��� ����� ������ �ٰ�.", "���� ���� Hungry �������� ������?", "�ð��� ������ Hungry �������� �پ��ž�. �� �������� ������ ������ ä�� �� �־�.", "������ ���� ������ ����ϸ� ���� �� �־�", "�׷� �������� ���� 5������ ��� �ٽ� �����Է� ��." });
        }


        if(Quest==2&&(playerctrl.foodCount>4))
        {
            Quest++;
            level.levelData = 2;
        }
          
        if(Quest==3)
        {
            Quest++;
            talkData.Remove(1);
            talkData.Add(1, new string[] { "����� ��� ���±���.", "���� ���ʸ� ���ϴ� ����� ������ �ٰ�. ���� ��ó�� ���� ���ʸ� ä���� �� �־�.", "���� Hp �������� ������?", "���ʸ� ������ �� Hp �������� ȸ�� �� �� �־�.", "����� Hp �������� ��� �پ��� GameOver�ϱ� �����ص�." ,"�׷� �������� ���� 5���� ���ؼ� �ٽ� �����Է� ��"});
        }

        if(Quest==4&& (playerctrl.medicineCount > 4))
        {
            Quest++;
            level.levelData = 3;
        }

        if(Quest==5)
        {
            Quest++;
            talkData.Remove(1);
            talkData.Add(1, new string[] { "���� ä���� ��� ���±���. �����߾�.", "�� �ñ��� ���� ������ �������� ���� ã�ƿ�." });
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
            else if (id == 3)
            {
                talkData.Add(3, new string[] { "�ȳ� ���� ������ �Ӹ���� ��" });
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
