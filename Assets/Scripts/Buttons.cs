using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Buttons : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField]
    AudioSource over, click;
    public void OnPointerEnter(PointerEventData eventData) => over.Play();
    public void OnPointerClick(PointerEventData eventData) => click.Play();
    public void Restart()
    {
        //GM.isPause = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneBuildIndex: 3);
    }
    public void GoToMainMenu() => SceneManager.LoadScene(sceneBuildIndex: 0);
    public void GoToLeaderBoards() => SceneManager.LoadScene(sceneBuildIndex: 4);
    public void QuitGame() => Application.Quit();
}