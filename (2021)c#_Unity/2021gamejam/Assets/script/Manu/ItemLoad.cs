using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ItemLoad : MonoBehaviour
{
    public int[,] ItemInfos = new int[10, 6];
    private int j = 0;

    void Start()
    {
        test();
    }

    void test()
    {
        StreamReader sr = new StreamReader(Application.dataPath + "/Resources/" + "ItemInfo.csv");

        bool endOfFile = false;
        while (!endOfFile)
        {
            string data_String = sr.ReadLine();
            if(data_String == null)
            {
                endOfFile = true;
                break;
            }
            var data_values = data_String.Split(',');
            for(int i = 1; i < data_values.Length; i++)
            {
                ItemInfos[j, i-1] = int.Parse(data_values[i]);
            }
            j++;
        }

    }
}