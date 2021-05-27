using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Shows the game scene
    public void PlayAgain()
    {
      SceneManager.LoadScene("Game2");
    }
    // Shows the Menu scene
    public void Menu()
    {
      SceneManager.LoadScene("Menu");
    }
    // Quits the game
    public void QuitGame()
    {
      Debug.Log("QUIT!");
      Application.Quit();
    }
}
