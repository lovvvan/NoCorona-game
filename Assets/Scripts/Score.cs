using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        if (Player.score > -14)
        {
            scoreText.text = "SCORE: " + Player.score.ToString();
        }
        else
        {
            scoreText.text = "null";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
