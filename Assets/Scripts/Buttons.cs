using UnityEngine;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField]
    AudioSource over, click;
    public void OnPointerEnter(PointerEventData eventData) => over.Play();
    public void OnPointerClick(PointerEventData eventData) => click.Play();
}