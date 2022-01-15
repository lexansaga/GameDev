using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    public Button btnPlayAgain;
   public void Start()
   {
		btnPlayAgain.onClick.AddListener(PlayAgain);
   }
   public void PlayAgain()
   {
       SceneManager.LoadScene("Level1");
   }
   public void LevelSelect()
   {
       SceneManager.LoadScene("LevelSelect");
   }
   public void Setup(int score)
   {
       gameObject.SetActive(true);
       pointsText.text = score.ToString();

        string difficulty = TextDB.ReadText(@"Assets\Resources\TextDB\LevelInfo.txt").Split(',')[3].Split(':')[1];
        Debug.Log(difficulty);
        TextDB.WriteString(@$"Assets\Resources\TextDB\Score{difficulty}.txt",score.ToString());
   }
}
