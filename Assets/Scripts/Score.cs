using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    #region Principal
    public static int score, highScore, totalPoints, aliensKilled;
    [SerializeField]
    private Text txtScore, txtHighScore;
    #endregion
    #region Estatisticas

    #endregion
    private void Awake()
    {
        // Carrega os valores
        highScore = PlayerPrefs.GetInt("highscores", highScore);
        totalPoints = PlayerPrefs.GetInt("totalpoints", totalPoints);
    }
    private void Start()
    {
        score = 0;
        txtHighScore.text = Score.highScore.ToString();
    }
    private void Update() => txtScore.text = score.ToString();
    public static void CheckHighScore()
    {
        totalPoints += score;
        if (score > Score.highScore)
            Score.highScore = score;

        SaveData();
    }
    public static void SaveData()
    {
        PlayerPrefs.SetInt("highscores", highScore);
        PlayerPrefs.SetInt("totalpoints", totalPoints);
        PlayerPrefs.SetInt("alienskilled", aliensKilled);

    }
}