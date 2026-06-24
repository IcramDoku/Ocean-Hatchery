using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool gameOver;

    private void Awake()
    {
        Debug.Log("GameManager Awake: " + GetInstanceID());
        Instance = this;
    }

    public void GameOver()
    {
        Debug.Log("GameOver called. gameOver = " + gameOver);

        if (gameOver)
            return;

        gameOver = true;

        Debug.Log("GAME OVER");

        ResetGame();
    }

    private void ResetGame()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.Score = 0;
        }

        PlayerPrefs.Save();

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}
