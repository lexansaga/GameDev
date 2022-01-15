using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class Timer : MonoBehaviour
{
    deployEnemies deployEnemies;
    deployExtras deployExtras;
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public float gameSpeedInitial = 1.0f;
    public float gameSpeedMultiplier = 0.05f;

  float dummyTimeRemaining;
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        dummyTimeRemaining = timeRemaining;
        
        deployEnemies = gameObject.GetComponent<deployEnemies>();
        deployExtras =  gameObject.GetComponent<deployExtras>();

     
     string[] levelInfo = TextDB.ReadText("Assets/Resources/TextDB/LevelInfo.txt").Split(',');
     float enemyRate = float.Parse(levelInfo[0].Split(':')[1], CultureInfo.InvariantCulture.NumberFormat);
     float extrasRate = float.Parse(levelInfo[1].Split(':')[1], CultureInfo.InvariantCulture.NumberFormat);
     float speed =float.Parse(levelInfo[2].Split(':')[1], CultureInfo.InvariantCulture.NumberFormat);

    deployEnemies.startDeployRate(enemyRate);
     deployExtras.startDeployRate(extrasRate);
     gameSpeedInitial = speed;

        Debug.Log("Enemy Rate : " + enemyRate);
        Debug.Log("Extras Rate : " + extrasRate);
        Debug.Log("Speed Rate : " + speed);

    }
    // public void SetGamePhase(float enemyRate,float extrasRate,float speed)
    // {
    //     Start();
    //     deployEnemies.startDeployRate(enemyRate);
    //      deployExtras.startDeployRate(extrasRate);
    //     gameSpeedInitial = speed;

    //     Debug.Log("Enemy Rate : " + enemyRate);
    //     Debug.Log("Extras Rate : " + extrasRate);
    //     Debug.Log("Speed Rate : " + speed);
    // }
    void Update()
    {
   
        if (timerIsRunning)
        {
            if (dummyTimeRemaining > 0)
            {
                dummyTimeRemaining -= Time.deltaTime;
            }
            else
            {
                if(gameSpeedInitial <= 2.0f)
                {
                gameSpeedInitial += gameSpeedMultiplier;
                Debug.Log(gameSpeedInitial);
                // This will speedup game
                Time.timeScale = gameSpeedInitial;
              
                deployEnemies.speedUpRespawnTime(0.1f);
                deployExtras.speedUpRespawnTime(0.1f);
                }
            

                Debug.Log("Time has run out!");
                dummyTimeRemaining = timeRemaining;
            }
        }
    }

  
}
