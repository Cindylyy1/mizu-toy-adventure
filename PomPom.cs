using UnityEngine;

public class PomPom : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided with pom pom");

            // Notify the GameManager to update the score
            GameManager.Instance.IncrementPomPomsCollected();

            // Destroy the pom pom object
            Destroy(gameObject);
        }
    }
}

