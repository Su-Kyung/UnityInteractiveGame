using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class w6_ScoreMng : MonoBehaviour
{
    public Text text;

    int score = 0;

    void OnCollisionEnter(Collision coll)
    {
        score += 10;
        text.text = "점수 " + score;
    }
}
