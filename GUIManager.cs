using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUIManager : MonoBehaviour
{
    public static GUIManager instance;

    [SerializeField] private TextMeshProUGUI score_Txt;

    private int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        score = 0;
        SetScoreDisplay();
    }

    private void SetScoreDisplay()
    {
        score_Txt.text = score.ToString();
    }

    public void ChangeScore(int value)
    {
        score += value;
        SetScoreDisplay();
        Debug.Log("Score changed: " + score); // Debug statement
    }
}

