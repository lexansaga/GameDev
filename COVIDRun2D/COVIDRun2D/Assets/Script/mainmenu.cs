using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene("Level1");
        Debug.Log("Start");
    }

    public void QUIT()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
