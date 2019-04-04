using System.Collections;
using UnityEngine;
public class MeteorController : MonoBehaviour
{
    [SerializeField]
    GameObject meteor;
    void Start()
    {
        StartCoroutine(Spawn(16));
    }
    IEnumerator Spawn(int timing)
    {
        Instantiate(meteor, Vector2.zero, Quaternion.identity);
        yield return new WaitForSeconds(timing);
        StartCoroutine(Spawn(timing));
    }
}