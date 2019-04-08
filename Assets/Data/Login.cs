using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    [SerializeField]
    private InputField nameField, passwordField;
    [SerializeField]
    private Button submitButton;
    private void Update()
    {
        if (nameField.isFocused && Input.GetKeyDown(KeyCode.Tab))
            passwordField.ActivateInputField();
        if (Input.GetKeyDown(KeyCode.Return))
            CallLogin();
    }
    public void CallLogin()
    {
        StartCoroutine(LoginCo());
    }
    IEnumerator LoginCo()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);

        WWW www = new WWW("https://citysleeping.000webhostapp.com/login.php", form);
        yield return www;
        if (www.text[0] == '0')
        {
            DBManager.username = nameField.text;
            DBManager.scoreDB = int.Parse(www.text.Split('\t')[1]);
            Menu.isLogged = true;
            SceneManager.LoadScene(0);
        }
    }
    public void VerifyInputs() => submitButton.interactable = (nameField.text.Length >= 3 && passwordField.text.Length >= 3);
}