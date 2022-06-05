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
        talkData.Add(1, new string[] { "안녕 나는 우뚝선 독수리라고 해.", "이 곳에 처음 왔구나?","그럼 지금부터 내가 조작법을 알려줄게.","W A S D 키를 누르면 앞 뒤 좌 우로 이동이 가능하고"+" 또한 스페이스바를 누르면 점프가 가능해.","NPC 가까이 가서 Q키를 누르면 NPC와 대화를 할 수 있어." ,
                                        "이제 돼지와 함께 춤을이라는 NPC를 찾아서 말을 걸고 다시 나에게로 와."});

        talkData.Add(2, new string[] { "안녕 나는 돼지와 함께 춤을이라고 해" });

        talkData.Add(3, new string[] { "안녕 나는 빛나는 머리라고 해" });


     
        nameData.Add(1, new string[] { "우뚝선 독수리" });
        nameData.Add(2, new string[] {"돼지와 함께 춤을"});
        nameData.Add(3, new string[] { "빛나는 머리" });
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
            talkData.Add(1, new string[] { "이제 음식을 얻는 방법을 가르쳐 줄게.", "지금 위에 Hungry 게이지가 보이지?", "시간이 지나면 Hungry 게이지가 줄어들거야. 이 게이지는 음식을 먹으면 채울 수 있어.", "음식은 옆에 동물을 사냥하면 얻을 수 있어", "그럼 이제부터 동물 5마리를 잡고 다시 나에게로 와." });
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
            talkData.Add(1, new string[] { "사냥을 모두 끝냈구나.", "이제 약초를 구하는 방법을 가르쳐 줄게. 약초 근처에 가면 약초를 채집할 수 있어.", "위에 Hp 게이지가 보이지?", "약초를 먹으면 이 Hp 게이지를 회복 할 수 있어.", "참고로 Hp 게이지가 모두 줄어들면 GameOver니까 주의해둬." ,"그럼 이제부터 약초 5개를 구해서 다시 나에게로 와"});
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
            talkData.Add(1, new string[] { "약초 채집을 모두 끝냈구나. 수고했어.", "또 궁금한 점이 있으면 언제든지 나를 찾아와." });
        }
    }
    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            talkData.Remove(id);
            if(id==1)
            {
                talkData.Add(1, new string[] { "안녕 나는 우뚝선 독수리라고 해." });
            }
            else if(id==2)
            {
                talkData.Add(2, new string[] { "안녕 나는 돼지와 함께 춤을이라고 해" });
                count++;
            }
            else if (id == 3)
            {
                talkData.Add(3, new string[] { "안녕 나는 빛나는 머리라고 해" });
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
