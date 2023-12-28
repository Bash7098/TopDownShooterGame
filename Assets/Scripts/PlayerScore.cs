using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public TMP_Text scoreText; // Reference to the TMP Text for displaying the score
    private int score = 0;

    void Start()
    {
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }
}
