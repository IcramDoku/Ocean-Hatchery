using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int Score;
    public int HighScore;

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

        Debug.Log(
            $"Score: {Score} | High Score: {HighScore}"
        );
    }
}
