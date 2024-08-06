using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public Text timerText; // Reference to the UI Text component for the timer
    public GameObject gameOverPanel; // Panel to show when the game is over
    public GameObject youWinPanel;   // Panel to show when the player wins
    public int totalPomPoms = 12;    // Total number of pom poms to collect

    private float timeRemaining = 180f; // 3 minutes in seconds
    private bool isGameOver = false;
    private int pomPomsCollected = 0;

    private void Start()
    {
        gameOverPanel.SetActive(false);  // Hide the game over panel initially
        youWinPanel.SetActive(false);    // Hide the win panel initially
    }

    private void Update()
    {
        if (!isGameOver)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                GameOver();
            }

            UpdateTimerDisplay();
        }
    }

    private void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining % 60f);
            timerText.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
        }
    }

    private void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);  // Show the game over panel
        youWinPanel.SetActive(false);   // Hide the win panel
    }

    public void Win()
    {
        if (isGameOver) return; // Prevent triggering win logic if the game is already over
        isGameOver = true;
        Debug.Log("Game Won!");
        youWinPanel.SetActive(true);    // Show the win panel
        gameOverPanel.SetActive(false); // Hide the game over panel
    }


    public void IncrementPomPomsCollected()
    {
        // Increment the count
        pomPomsCollected++;

        // Log the current count
        Debug.Log($"PomPoms collected: {pomPomsCollected}");

        // Check if the win condition is met
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if (pomPomsCollected >= totalPomPoms && !isGameOver)
        {
            // Log win condition
            Debug.Log("All pom poms collected! Winning the game.");
            Win();
        }
    }



    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reload the current scene
    }
}





