using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  //Loads the game scene
    public void PlayGame()
    {
      SceneManager.LoadScene("Game");
    }

//Quits the game
    public void QuitGame()
    {
      Debug.Log("QUIT!");
      Application.Quit();
    }

}
