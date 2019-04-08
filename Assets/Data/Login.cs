using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    [SerializeField]
    private InputField _nameField, _passwordField;
    [SerializeField]
    private Button _submitButton;
    public void CallLogin()
    {
        StartCoroutine(LoginCo());
    }
    IEnumerator LoginCo()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", _nameField.text);
        form.AddField("password", _passwordField.text);

        WWW www = new WWW("https://citysleeping.000webhostapp.com/login.php", form);
        yield return www;
        if (www.text[0] == '0')
        {
            DBManager.Username = _nameField.text;
            DBManager.ScoreDB = int.Parse(www.text.Split('\t')[1]);
            Menu.IsLogged = true;
            SceneManager.LoadScene(0);
        }
    }
    public void VerifyInputs() => _submitButton.interactable = (_nameField.text.Length >= 3 && _passwordField.text.Length >= 3);
}