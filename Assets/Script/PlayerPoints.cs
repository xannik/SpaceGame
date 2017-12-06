using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    private int score = 0;

    public void addPoint(int point)
    {
        score += point;
    }

    public int getScore()
    {
        return (score);
    }
}