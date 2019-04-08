using System.Collections;
using UnityEngine;
public class MeteorController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ufos;
    [SerializeField]
    private GameObject[] ufoSpawners;
    [SerializeField]
    private int spawn;
    public static int totalMet = 0;
    private static byte totalUfo;
    public static int metNumOnScreen;
    public static byte TotalUfo { get => totalUfo; set => totalUfo = value; }
    void Start()
    {
        TotalUfo = 0;
        metNumOnScreen = 0;
    }
    private void FixedUpdate()
    {
        //print("Meteoros na tela: " + metNumOnScreen);
        if (totalMet != 0 && (totalMet % 20) == 0 && TotalUfo < 1)
            StartCoroutine(SpawnUfo(a: Random.Range(0, 2), b: SetSpawnerUfo()));
    }
    int SetSpawnerUfo() => spawn = Random.Range(0, ufoSpawners.Length);
    IEnumerator SpawnUfo(int a, int b)
    {
        Instantiate(ufos[a], ufoSpawners[b].transform.position, Quaternion.identity);
        TotalUfo++;
        yield return new WaitForSeconds(5);
    }
}