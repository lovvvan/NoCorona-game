using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Shows the game scene
    public void PlayAgain()
    {
      SceneManager.LoadScene("Game");
    }

    // Quits the game
    public void QuitGame()
    {
      Debug.Log("QUIT!");
      Application.Quit();
    }
}
