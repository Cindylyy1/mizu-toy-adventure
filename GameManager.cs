using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject pomPomPrefab;
    public int totalPomPoms = 12;
    private int pomPomsCollected = 0;
    public Vector2 mapMinBounds;
    public Vector2 mapMaxBounds;
    public GameObject exit;
    public Text scoreText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SpawnPomPoms();
        exit.SetActive(false);
        UpdateScoreText(); // Update the score text at the start
    }

    private void SpawnPomPoms()
    {
        for (int i = 0; i < totalPomPoms; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(mapMinBounds.x, mapMaxBounds.x),
                0.5f,  // Adjust according to your map's Y level
                Random.Range(mapMinBounds.y, mapMaxBounds.y)
            );
            Instantiate(pomPomPrefab, randomPosition, Quaternion.identity);
        }
    }

    public void IncrementPomPomsCollected()
    {
        pomPomsCollected++;
        Debug.Log("PomPom collected. Total: " + pomPomsCollected); // Display the correct score
        UpdateScoreText();
        if (pomPomsCollected >= totalPomPoms)
        {
            exit.SetActive(true);
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + pomPomsCollected; // Display the correct score
        }
    }
}




