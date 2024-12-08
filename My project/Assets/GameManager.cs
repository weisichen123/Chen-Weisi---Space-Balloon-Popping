using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;

    public int currentLevel = 1; 
    public int maxLevel = 3; 
    public TextMeshProUGUI levelText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreText();
        UpdateLevelText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
        AdvanceLevel(); 
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    private void UpdateLevelText()
    {
        if (levelText != null)
        {
            levelText.text = "Level: " + currentLevel;
        }
    }

    public void AdvanceLevel()
    {
        if (currentLevel < maxLevel)
        {
            currentLevel++;
            UpdateLevelText();
            Debug.Log("Advanced to Level " + currentLevel);

            AdjustDifficulty();
        }
        else
        {
            Debug.Log("Game Completed!"); 
            GameOver();
        }
    }

    public void RestartLevel()
    {
        Debug.Log("Restarting Level " + currentLevel);
      
    }

    private void AdjustDifficulty()
    {

        BalloonMovement.Instance.AdjustForLevel(currentLevel);
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0;
    }
}


