using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    #region Principal
    public static int score, highScore, totalPoints, aliesKilled;
    [SerializeField]
    private Text txtScore, txtHighScore;
    #endregion
    #region Estatisticas

    #endregion
    private void Start()
    {
        // Carrega os valores
        highScore = PlayerPrefs.GetInt("highscore", highScore);
        totalPoints = PlayerPrefs.GetInt("totalpoints", totalPoints);

        score = 0;
        txtHighScore.text = highScore.ToString();
    }
    private void Update()
    {
        txtScore.text = score.ToString();
    }
    public static void CheckHighScore()
    {
        totalPoints += score;
        if (score > highScore)
            highScore = score;
    }
    public static void SaveData()
    {
        PlayerPrefs.SetInt("highscores", highScore);
        PlayerPrefs.SetInt("totalpoints", totalPoints);
    }
}