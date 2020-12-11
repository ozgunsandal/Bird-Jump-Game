using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public static Score instance;

    void Start()
    {
        scoreText.alpha = 0.7f;
        if(instance == null) 
        {
            instance = this;
        }
    }
    public void setScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
