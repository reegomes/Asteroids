using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class HighScore : MonoBehaviour
{
    public Text playerDisplay, scoreDisplay;
    public InputField nickname;
    private void Awake()
    {
        playerDisplay.text = "Player: " + DBManager.nickname;
        scoreDisplay.text = "Score: " + DBManager.scoreDB;
    }
    public void CallSaveData()
    {
        DBManager.nickname = nickname.text;
        DBManager.scoreDB = Score.highScore;
        StartCoroutine(SavePlayerData());
    }
    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("nickname", DBManager.nickname);
        form.AddField("scoreDB", DBManager.scoreDB);

        WWW www = new WWW("https://citysleeping.000webhostapp.com/leaderboard.php");
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("Game Saved.");
        }
        else
        {
            Debug.Log("Save failed. Error #" + www.text);
        }
    }
}