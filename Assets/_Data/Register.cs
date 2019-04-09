using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
public class Register : MonoBehaviour
{
    [SerializeField]
    private InputField _nameField, _passwordField;
    [SerializeField]
    private Button _submitButton;
    public void CallRegister()
    {
        StartCoroutine(RegisterCo());
    }
    IEnumerator RegisterCo()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", _nameField.text);
        form.AddField("password", _passwordField.text);

        WWW www = new WWW("https://citysleeping.000webhostapp.com/register.php", form);
        yield return www;

        if (www.text == "0")
            SceneManager.LoadScene(0);
    }
    public void VerifyInputs()
    {
        _submitButton.interactable = (_nameField.text.Length >= 3 && _passwordField.text.Length >= 3);
    }
}