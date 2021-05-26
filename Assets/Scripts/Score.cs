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
        if (Player.score > 0)
        {
            scoreText.text = Player.score.ToString();
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
