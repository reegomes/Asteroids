using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    #region Principal
    public static int CurrentScore, CurrentHighScore, TotalPoints, AliensKilled;
    [SerializeField]
    private Text _txtScore, _txtHighScore;
    #endregion
    private void Awake()
    {
        // Carrega os valores
        CurrentHighScore = PlayerPrefs.GetInt("highscores", CurrentHighScore);
        TotalPoints = PlayerPrefs.GetInt("totalpoints", TotalPoints);
    }
    private void Start()
    {
        CurrentScore = 0;
        _txtHighScore.text = Score.CurrentHighScore.ToString();
    }
    private void Update()
    {
        _txtScore.text = CurrentScore.ToString();
    }
    public static void CheckHighScore()
    {
        TotalPoints += CurrentScore;
        if (CurrentScore > Score.CurrentHighScore)
            Score.CurrentHighScore = CurrentScore;

        SaveData();
    }
    public static void SaveData()
    {
        PlayerPrefs.SetInt("highscores", CurrentHighScore);
        PlayerPrefs.SetInt("totalpoints", TotalPoints);
        PlayerPrefs.SetInt("alienskilled", AliensKilled);

    }
}