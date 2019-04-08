using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Buttons : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField]
    AudioSource over, click;
    [SerializeField]
    private GameObject pausePanel;
    public void OnPointerEnter(PointerEventData eventData) => over.Play();
    public void OnPointerClick(PointerEventData eventData) => click.Play();
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneBuildIndex: 3);
    }
    public void Resume()
    {
        GM.isPause = false;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
    public void GoToMainMenu() => SceneManager.LoadScene(sceneBuildIndex: 0);
    public void GoToLeaderBoards() => SceneManager.LoadScene(sceneBuildIndex: 4);
    public void QuitGame() => Application.Quit();
}