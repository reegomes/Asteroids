using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField]
    AudioSource over, click;
    public void OnPointerEnter(PointerEventData eventData) => over.Play();
    public void OnPointerClick(PointerEventData eventData) => click.Play();
    public void Restart() => SceneManager.LoadSceneAsync(sceneBuildIndex: 0b0);
}