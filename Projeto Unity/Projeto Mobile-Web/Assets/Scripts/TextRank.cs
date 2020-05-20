using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextRank : MonoBehaviour
{
    public Rank rank;

    Text text;

    int Class = 1;
    int aux = 0;

    void Start()
    {
        text = GetComponent<Text>();

        rank.Score.Sort();
        rank.Score.Reverse();

        while(rank.Score.Count > 20)
        {
            if (rank.Score.Count > 20)
            {
                rank.Score.Remove(rank.Score[rank.Score.Count-1]);
            }

            if (aux > 100)
                return;
            aux++;
            print(aux);
        }

        foreach (int i in rank.Score)
        {
            text.text = text.text + "\n" + Class + "°" + " " + "------------------------------------" + " " + i;
            Class++;
        }

    }

    // Update is called once per frame
    void Update()
    {



    }
}
