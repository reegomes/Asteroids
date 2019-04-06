using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
public class Register : MonoBehaviour
{
    [SerializeField]
    private InputField nameField, passwordField;
    [SerializeField]
    private Button submitButton;
    public void CallRegister()
    {
        StartCoroutine(RegisterCo());
    }
    IEnumerator RegisterCo()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);

        WWW www = new WWW("https://citysleeping.000webhostapp.com/register.php", form);
        yield return www;

        if (www.text == "0")
        {
            // apagar o debug
            Debug.Log("Success");
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("User creation failed. Error #" + www.text);
        }
    }
    public void VerifyInputs() => submitButton.interactable = (nameField.text.Length >= 3 && passwordField.text.Length >= 3);
}