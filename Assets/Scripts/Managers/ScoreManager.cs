using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int Score;
    public int HighScore;

    public TMP_Text currentScoreText;
    public TMP_Text highScoreText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        HighScore = PlayerPrefs.GetInt(
            "HighScore",
            0
        );

        UpdateUI();
    }

    public void AddScore(int amount)
    {
        Score += amount;

        if (Score > HighScore)
        {
            HighScore = Score;

            PlayerPrefs.SetInt(
                "HighScore",
                HighScore
            );

            PlayerPrefs.Save();
        }

        UpdateUI();

        Debug.Log(
            $"Score: {Score} | High Score: {HighScore}"
        );
    }

    public void ResetScore()
    {
        Score = 0;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (currentScoreText != null)
        {
            currentScoreText.text =
                $"Score: {Score}";
        }

        if (highScoreText != null)
        {
            highScoreText.text =
                $"High Score: {HighScore}";
        }
    }
}