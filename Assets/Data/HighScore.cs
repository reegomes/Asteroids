using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class HighScore : MonoBehaviour
{
    public Text playerDisplay, scoreDisplay, txtTotalPoints, txtaliesKilled;
    private void Awake()
    {
        playerDisplay.text = "Player: " + DBManager.username;
        scoreDisplay.text = "Score: " + Score.highScore;
        txtTotalPoints.text = "Meteors Destroyed: " + Score.totalPoints;
        txtaliesKilled.text = "Killed Aliens: " + Score.aliesKilled;
        DBManager.scoreDB = Score.highScore;
    }
    private void Start()
    {
        print(DBManager.username);
        print(DBManager.scoreDB);
    }
    public void CallSaveData()
    {
        DBManager.scoreDB = Score.highScore;
        StartCoroutine(SavePlayerData());
    }
    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", DBManager.username);
        form.AddField("scoreDB", DBManager.scoreDB);

        WWW www = new WWW("https://citysleeping.000webhostapp.com/leaderboard.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("Submit.");
        }
        else
        {
            Debug.Log("Save failed. Error #" + www.text);
        }

        DBManager.LogOut();
    }
}