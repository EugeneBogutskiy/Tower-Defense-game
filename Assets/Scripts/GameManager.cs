using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public Text scoreText;

    private bool isGameEnded;

    void Start()
    {
        isGameEnded = false;
    }

    void Update()
    {
        if (isGameEnded)
        {
            return;
        }

        if (PlayerStats.lives <= 0)
        {
            gameOverUI.SetActive(true);
            EndGame();
        }
    }

    void EndGame()
    {
        scoreText.text = "enemies killed: " + PlayerStats.enemyСounter.ToString();
        isGameEnded = true;
        Time.timeScale = 0;
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
