using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void QUIT()
    {
        Application.Quit();
    }
}
