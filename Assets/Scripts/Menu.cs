using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    [SerializeField]
    private Button registerButton, loginButton;
    [SerializeField]
    private Text txtOffline;
    public static bool isLogged;
    private void Start()
    {
        if (isLogged == true)
        {
            registerButton.interactable = false;
            loginButton.interactable = false;
            txtOffline.text = "Play Asteroids";
        }
        else
            txtOffline.text = "Play Offline";
    }
    public void GoToRegister() => SceneManager.LoadScene(1);
    public void GoToLogin() => SceneManager.LoadScene(2);
    public void GoToMainMenu() => SceneManager.LoadScene(0);
    public void GoToLeaderBoards() => SceneManager.LoadScene(4);
    public void GoToGame() => SceneManager.LoadScene(3);
    public void SaveGameOnQuit()
    {
        // Por garantia
        PlayerPrefs.Save();
        // OnApplicationQuit já chama o PlayerPrefs, mas..
        Application.Quit();
    }
}