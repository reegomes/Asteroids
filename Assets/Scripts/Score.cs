using UnityEngine;

public class Score : MonoBehaviour
{

    public static int score;
    public static int highScore;
    private void Update()
    {
        Debug.Log(string.Format("Score: {0}", score));
    }
}