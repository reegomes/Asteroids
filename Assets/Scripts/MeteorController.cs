using System.Collections;
using UnityEngine;
public class MeteorController : MonoBehaviour
{
    [SerializeField]
    private GameObject meteor;
    [SerializeField]
    private GameObject[] spawners;
    int spawn;
    void Start()
    {
        StartCoroutine(Spawn(10, SetSpawner()));
    }
    int SetSpawner()
    {
        return spawn = Random.Range(0, spawners.Length);
    }
    IEnumerator Spawn(int timing, int i)
    {
        Instantiate(meteor, spawners[i].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timing);
        StartCoroutine(Spawn(timing, SetSpawner()));
    }
}