using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Runtime;
using System;
using System.Linq;
using UnityEngine.UI;
public class LevelSelect : MonoBehaviour
{
   

   public TextMeshProUGUI ScoreEasy,ScoreMedium,ScoreHard;

 public void Start()
 {
        ScoreEasy.text =  GetHighestScore("Easy").ToString();
        ScoreMedium.text =  GetHighestScore("Medium").ToString();
        ScoreHard.text =  GetHighestScore("Hard").ToString();
 }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Home");
    }

   int GetHighestScore(string level)
   {
      string[] score = TextDB.ReadStringArray($"Assets/Resources/TextDB/Score{level}.txt");
      int[] scoreInt = Array.ConvertAll(score, s => int.Parse(s));
      Debug.Log(score[0]);
      Debug.Log(scoreInt[0]);

    //  return "0";
      if(scoreInt == null)
      {
        return 0;
      }
      else
      {

      // int maxIndex = scoreInt.Max();
      // int p = Array.IndexOf(scoreInt, maxIndex);

      int m = scoreInt.Max();

// Positioning max
    int p = Array.IndexOf(scoreInt, m);

      return m;

      }
    
   }
  
   
    public void LoadLevel(string level)
    {
      //  Timer timer = new Timer();
        float enemyRate = 0f;
        float extrasRate = 0f;
        float speed = 0f;

       
        if(level.Contains("Easy"))
        {
            enemyRate = 3.0f;
            extrasRate = 5.0f;
            speed = 1.0f;

         
         TextDB.OverwriteText("Assets/Resources/TextDB/LevelInfo.txt",@$"EnemyRate:{enemyRate},ExtrasRate:{extrasRate},Speed:{speed},Level:Easy");
         //  timer.SetGamePhase(enemyRate,extrasRate,speed);
          SceneManager.LoadScene("Level1");
        
        }
        if(level.Contains("Medium"))
        {
            enemyRate = 2.0f;
            extrasRate = 3.5f;
            speed = 1.5f;

              TextDB.OverwriteText("Assets/Resources/TextDB/LevelInfo.txt",@$"EnemyRate:{enemyRate},ExtrasRate:{extrasRate},Speed:{speed},Level:Medium");
           SceneManager.LoadScene("Level1");
        //    timer.SetGamePhase(enemyRate,extrasRate,speed);
        }
        if(level.Contains("Hard"))
        {
            enemyRate = 1.0f;
            extrasRate = 2.5f;
            speed = 2.0f;

              TextDB.OverwriteText("Assets/Resources/TextDB/LevelInfo.txt",@$"EnemyRate:{enemyRate},ExtrasRate:{extrasRate},Speed:{speed},Level:Hard");
           SceneManager.LoadScene("Level1");
           //  timer.SetGamePhase(enemyRate,extrasRate,speed);
        }
    }

    
}
