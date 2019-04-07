using System.Collections;
using UnityEngine;
public class Check : MonoBehaviour
{
    IEnumerator Start()
    {
        WWW request = new WWW("https://citysleeping.000webhostapp.com/check.php");
        yield return request;
        string[] webResults = request.text.Split('\t');
        Debug.Log(webResults[0]);
        int webNumber = int.Parse(webResults[1]);
        webNumber *= 2;
    }
}