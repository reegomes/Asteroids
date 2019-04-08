using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class Top : MonoBehaviour
{
    [SerializeField]
    private string[] rank;
    [SerializeField]
    private Text txtTop;
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
                rank = rankingString.Split(';');
                txtTop.text = this.ToString();
            }
        }
    }
    public override string ToString()
    {
        //perdão pela gambiarra, o tempo é curto :v
        return rank[0] + "\n" + rank[1] + "\n" + rank[2] + "\n" + rank[3] + "\n" + rank[4] + "\n" + rank[5] + "\n" + rank[6] + "\n" + rank[7] + "\n" + rank[8] + "\n" + rank[9];
    }
}