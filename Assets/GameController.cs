using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    private int lives = 3;
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        AddScore(0);
    }
    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString("000000");
    }
    public void PlayerHit()
    {
        lives--;
        if(lives <= 0)
        {
            PlayerDie();
        }
    }

    private void PlayerDie()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
