using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    [SerializeField]
    private Button _registerButton, _loginButton;
    [SerializeField]
    private Text _txtOffline;
    public static bool IsLogged;
    private void Start()
    {
        if (IsLogged == true)
        {
            _registerButton.interactable = false;
            _loginButton.interactable = false;
            _txtOffline.text = "Play Asteroids";
        }
        else
            _txtOffline.text = "Play Offline";
    }
    public void GoToRegister()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToLogin()
    {
        SceneManager.LoadScene(2);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void GoToLeaderBoards()
    {
        SceneManager.LoadScene(4);
    }
    public void GoToGame()
    {
        SceneManager.LoadScene(3);
    }
    public void SaveGameOnQuit()
    {
        // Por garantia
        PlayerPrefs.Save();
        // OnApplicationQuit já chama o PlayerPrefs, mas..
        Application.Quit();
    }
}