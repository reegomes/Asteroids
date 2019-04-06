using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public static int score, highScore = 1000, totalPoints;
    [SerializeField]
    private Text txtScore, txtHighScore;
    private void Start()
    {
        score = 0;
        txtHighScore.text = highScore.ToString();
    }
    private void Update()
    {
        //Debug.Log(string.Format("Score: {0}", score));
        txtScore.text = score.ToString();
    }
    public static void CheckHighScore()
    {
        totalPoints += score;
        if (score > highScore)
            highScore = score;
    }
}