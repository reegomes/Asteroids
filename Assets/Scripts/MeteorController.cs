using System.Collections;
using UnityEngine;
public class MeteorController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _ufos;
    [SerializeField]
    private GameObject[] _ufoSpawners;
    [SerializeField]
    private int _spawn;
    public static int TotalMet = 0;
    private static byte _totalUfo;
    public static int MetNumOnScreen;
    public static byte TotalUfo { get => _totalUfo; set => _totalUfo = value; }
    void Start()
    {
        TotalUfo = 0;
        MetNumOnScreen = 0;
    }
    private void FixedUpdate()
    {
        //print("Meteoros na tela: " + metNumOnScreen);
        if (TotalMet != 0 && (TotalMet % 20) == 0 && TotalUfo < 1)
            StartCoroutine(SpawnUfo(a: Random.Range(0, 2), b: SetSpawnerUfo()));
    }
    int SetSpawnerUfo() => _spawn = Random.Range(0, _ufoSpawners.Length);
    IEnumerator SpawnUfo(int a, int b)
    {
        Instantiate(_ufos[a], _ufoSpawners[b].transform.position, Quaternion.identity);
        TotalUfo++;
        yield return new WaitForSeconds(5);
    }
}