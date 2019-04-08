using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Input;
public class InputMenu : MonoBehaviour
{
    #region Input dos menus
    [SerializeField]
    private Controls _control;
    [SerializeField]
    private InputAction _escape;
    public bool EscapeKey { get; set; }
    #endregion
    #region Controle do painel
    [SerializeField]
    private Text _txtPause, _btnTxt;
    [SerializeField]
    private GameObject _pausePanel;
    #endregion
    private void Awake()
    {
        _escape.started += context => EscapeKey = true;
        _escape.cancelled += context => EscapeKey = false;
    }
    private void OnEnable()
    {
        _escape.Enable();
    }
    private void OnDisable()
    {
        //escape.Disable();
    }
    void Update()
    {
        if (EscapeKey == true)
        {
            Time.timeScale = 0f;
            _txtPause.text = "Paused";
            _pausePanel.SetActive(true);
            GM.IsPause = true;
        }
    }
}