using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HighScore : MonoBehaviour
{
    [SerializeField]
    private Text _playerDisplay, _scoreDisplay, _txtTotalPoints, _txtaliesKilled;
    private void Awake()
    {
        _playerDisplay.text = "Player: " + DBManager.Username;
        _scoreDisplay.text = "Score: " + Score.CurrentHighScore;
        _txtTotalPoints.text = "Meteors Destroyed: " + Score.TotalPoints;
        _txtaliesKilled.text = "Killed Aliens: " + Score.AliensKilled;
        DBManager.ScoreDB = Score.CurrentHighScore;
    }
    public void CallSaveData()
    {
        DBManager.ScoreDB = Score.CurrentHighScore;
        StartCoroutine(SavePlayerData());
    }
    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", DBManager.Username);
        form.AddField("scoreDB", DBManager.ScoreDB);

        WWW www = new WWW("https://citysleeping.000webhostapp.com/leaderboard.php", form);
        yield return www;
        if (www.text == "0")
            SceneManager.LoadScene(0);

        DBManager.LogOut();
    }
}