using UnityEngine;
using UnityEngine.UI;
public class Pause : MonoBehaviour
{
    [SerializeField]
    private Text txtPause, btnTxt;
    [SerializeField]
    private GameObject pausePanel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GM.isPause == false)
        {
            Time.timeScale = 0f;
            btnTxt.text = "Restart";
            txtPause.text = "Paused";
            pausePanel.SetActive(true);
            GM.isPause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && GM.isPause == true)
        {
            Time.timeScale = 1f;
            btnTxt.text = "Play Again";
            txtPause.text = "Game Over";
            pausePanel.SetActive(false);
            GM.isPause = false;
        }
    }
}