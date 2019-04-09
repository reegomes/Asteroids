using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Buttons : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField]
    private AudioSource _over, _click;
    [SerializeField]
    private GameObject _pausePanel;
    public void OnPointerEnter(PointerEventData eventData)
    {
        _over.Play();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        _click.Play();
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneBuildIndex: 3);
    }
    public void Resume()
    {
        GameManager.IsPause = false;
        Time.timeScale = 1;
        _pausePanel.SetActive(false);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
    public void GoToLeaderBoards()
    {
        SceneManager.LoadScene(sceneBuildIndex: 4);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}