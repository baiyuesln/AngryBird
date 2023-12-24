using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class GameSO : ScriptableObject
{
    public MapSO[] mapArray;
    public int selectedMapID = -1;
    public int selectedLevelID = -1;

    public void UpdateLevel(int number)
    {
        if(number<=0) return;
        if (number > mapArray[selectedMapID-1].starNumberOfLevel[selectedLevelID - 1])
        {
            mapArray[selectedMapID - 1].starNumberOfLevel[selectedLevelID - 1] = number;
            int sum = 0;
            foreach(int num in mapArray[selectedMapID - 1].starNumberOfLevel)
            {
                if(num > 0)
                {
                    sum += num;
                }
            }
            mapArray[selectedMapID - 1].starNumberOfMap = sum;

            //�����ʱ�ؿ������һ�ز��Ҵ˵�ͼ�������һ��
            if(selectedMapID<mapArray.Length && selectedLevelID>= mapArray[selectedMapID - 1].starNumberOfLevel.Length)
            {
                //�����һ����ͼû�п���
                if (mapArray[selectedMapID].starNumberOfMap == -1)
                {
                    //�����¸���ͼ�͵�һ��
                    mapArray[selectedMapID].starNumberOfMap = 0;
                    mapArray[selectedMapID].starNumberOfLevel[0] = 0;
                }
            }
            else
            {
                //�ж���һ���Ƿ���
                if(mapArray[selectedMapID - 1].starNumberOfLevel[selectedLevelID] == -1)
                {
                    mapArray[selectedMapID-1].starNumberOfLevel[selectedLevelID] = 0;
                }
            }
        }

    }
}
