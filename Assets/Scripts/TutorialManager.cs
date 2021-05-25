using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
  public GameObject[] popUps;
  private int popUpIndex;
  public GameObject EnemySpawn;
  public float waitTime1 = 2f;
  public float waitTime2 = 4f;

    // Update is called once per frame
    // The for-loop loops thorugh the pop-ups and activates the relevant one.
    // If it is pop-up 0, it waits until the player has moved the character before going to the next one
    // If it is popup 1, it waits 2 seconds before activating enemies and then removes the popup after another 2 seconds.
    void Update()
    {
      for (int i = 0; i < popUps.Length; i++)
      {
        if(i == popUpIndex)
        {
          popUps[i].SetActive(true);
        }
        else
        {
          popUps[i].SetActive(false);
        }
      }
      if(popUpIndex==0)
      {
        if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {
          popUpIndex++;
        }
      }
      else if(popUpIndex==1)
      {
        if(waitTime1<=0)
        {
          Debug.Log("Enemy spawn 1!");
          EnemySpawn.SetActive(true);
          waitTime2-=Time.deltaTime;
        }
        else
        {
          waitTime1-=Time.deltaTime;
        }
        if(waitTime2<=0)
        {
          Debug.Log("Enemy spawn 2!");
          popUpIndex++;
        }
        else
        {
          waitTime2-=Time.deltaTime;
        }
      }
    }
}
