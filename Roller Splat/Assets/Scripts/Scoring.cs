using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public Text scoring;
    private int timeLeft;
    public string rank;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = PlayerPrefs.GetInt("Time Left");
        rank = CalScore(timeLeft);
        scoring.text = ("Your ranking is " + rank);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public string CalScore(int timeLeft)
    {
        rank = "NA";
        if(timeLeft >= 45)
        {
            rank = "Gold";
        }

        else if(timeLeft >= 30 && timeLeft < 45)
        {
            rank = "Silver";
        }

        else if(timeLeft < 30)
        {
            rank = "Bronze";
        }

        return rank;
    }
}
