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
   public void Setup(int score)
   {
       gameObject.SetActive(true);
       pointsText.text = score.ToString();
   }
}
