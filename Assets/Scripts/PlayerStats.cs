using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int gold;
    public int startGold = 0;
    public Text momeyText;

    public static int lives;
    public int startLives = 10;
    public Text livesText;

    public static int enemyСounter;

    void Start()
    {
        gold = startGold;
        lives = startLives;
        enemyСounter = 0;
    }

    void Update()
    {
        momeyText.text = "Gold: " + gold.ToString();
        livesText.text = "Lives: " + lives.ToString();
    }
}
