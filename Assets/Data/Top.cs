using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class Top : MonoBehaviour
{
    [SerializeField]
    private string[] _rank;
    [SerializeField]
    private Text _txtTop;
    private void Start() => StartCoroutine(GetText());
    IEnumerator GetText()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://citysleeping.000webhostapp.com/Ranking.php"))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string rankingString = www.downloadHandler.text;
                _rank = rankingString.Split(';');
                _txtTop.text = this.ToString();
            }
        }
    }
    public override string ToString()
    {
        //perdão pela gambiarra, o tempo é curto :v
        return _rank[0] + "\n" + _rank[1] + "\n" + _rank[2] + "\n" + _rank[3] + "\n" + _rank[4] + "\n" + _rank[5] + "\n" + _rank[6] + "\n" + _rank[7] + "\n" + _rank[8] + "\n" + _rank[9];
    }
}