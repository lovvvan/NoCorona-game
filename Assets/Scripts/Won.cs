using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Won : MonoBehaviour
{
    public void PlayAgain()
    {
        Debug.Log("play!!!");
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
