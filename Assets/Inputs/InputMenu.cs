using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Input;
public class InputMenu : MonoBehaviour
{
    #region Input dos menus
    [SerializeField]
    private Controls control;
    [SerializeField]
    private InputAction tab, escape, returnKey;
    public bool EscapeKey { get; set; }
    private float TabKey { get; set; }
    private float ReturnKey { get; set; }
    #endregion
    #region Controle do painel
    [SerializeField]
    private Text txtPause, btnTxt;
    [SerializeField]
    private GameObject pausePanel;
    #endregion
    private void Awake()
    {
        tab.performed += context => TabKey = 1;
        tab.cancelled += context => TabKey = 0;

        escape.started += context => EscapeKey = true;
        escape.cancelled += context => EscapeKey = false;

        returnKey.performed += context => ReturnKey = 1;
        returnKey.cancelled += context => ReturnKey = 0;
    }
    private void OnEnable()
    {
        tab.Enable();
        escape.Enable();
        returnKey.Enable();
    }
    private void OnDisable()
    {
        tab.Disable();
        //escape.Disable();
        returnKey.Disable();
    }
    void Update()
    {
        if (EscapeKey == true)
        {
            Time.timeScale = 0f;
            txtPause.text = "Paused";
            pausePanel.SetActive(true);
            GM.isPause = true;
        }
    }
}