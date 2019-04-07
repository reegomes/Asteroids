using System.Collections;
using UnityEngine;
public class MeteorController : MonoBehaviour
{
    [SerializeField]
    private GameObject meteor;
    [SerializeField]
    private GameObject[] ufos;
    [SerializeField]
    private GameObject[] spawners;
    [SerializeField]
    private GameObject[] ufoSpawners;
    [SerializeField]
    private int spawn, totalMet = 0;
    private static byte totalUfo;
    public static int metNumOnScreen;
    public static byte TotalUfo { get => totalUfo; set => totalUfo = value; }

    void Start()
    {
        TotalUfo = 0;
        metNumOnScreen = 0;
        StartCoroutine(Spawn(5, SetSpawner()));
    }
    private void FixedUpdate()
    {
        if (totalMet != 0 && (totalMet % 20) == 0 && TotalUfo < 1)
            StartCoroutine(SpawnUfo(a: Random.Range(0, 2), b: SetSpawnerUfo()));
    }
    int SetSpawner() => spawn = Random.Range(0, spawners.Length);
    int SetSpawnerUfo() => spawn = Random.Range(0, ufoSpawners.Length);
    IEnumerator Spawn(int timing, int i)
    {
        yield return new WaitForSeconds(timing);
        if (metNumOnScreen <= 9)
        {
            totalMet++;
            Instantiate(meteor, spawners[i].transform.position, Quaternion.identity);
            StartCoroutine(Spawn(timing, SetSpawner()));
        }
        else
        {
            StartCoroutine(Spawn(timing, SetSpawner()));
        }
    }
    IEnumerator SpawnUfo(int a, int b)
    {
        Instantiate(ufos[a], ufoSpawners[b].transform.position, Quaternion.identity);
        TotalUfo++;
        yield return new WaitForSeconds(5);
    }
}