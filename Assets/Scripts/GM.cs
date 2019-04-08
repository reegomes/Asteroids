using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GM : MonoBehaviour
{
    #region Singleton
    private static GM _instance;
    public static GM Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GM");
                go.AddComponent<GM>();
            }
            return _instance;
        }
    }
    #endregion
    #region Pause Global
    public static bool IsPause { get; set; }
    #endregion
    #region Instanciação dos meteoros
    [SerializeField]
    private GameObject _meteorPrefab, _mediumMeteorPrefab, _smallMeteorPrefab;
    private int _meteorsToSpawn = 30;
    [SerializeField]
    private GameObject[] _spawners;
    [SerializeField]
    private List<GameObject> _meteorsList = new List<GameObject>();
    [SerializeField]
    private List<GameObject> _mediumMeteorsList = new List<GameObject>();
    [SerializeField]
    private List<GameObject> _smallMeteorsList = new List<GameObject>();
    #endregion
    private void Awake() => _instance = this;
    private void Start()
    {
        IsPause = false;
        for (int i = 0; i < _meteorsToSpawn; i++)
        {
            int metSpawnSelected = Random.Range(0, _spawners.Length);

            // Container grande
            GameObject meteors = Instantiate(_meteorPrefab, _spawners[metSpawnSelected].transform.position, Quaternion.identity) as GameObject;
            meteors.transform.parent = _spawners[metSpawnSelected].transform;
            meteors.SetActive(false);
            _meteorsList.Add(meteors);
            // Container médio
            GameObject mediumMeteors = Instantiate(_mediumMeteorPrefab, _spawners[metSpawnSelected].transform.position, Quaternion.identity) as GameObject;
            mediumMeteors.transform.parent = _spawners[metSpawnSelected].transform;
            mediumMeteors.SetActive(false);
            _mediumMeteorsList.Add(mediumMeteors);
            // Container pequeno
            GameObject smallMeteors = Instantiate(_smallMeteorPrefab, _spawners[metSpawnSelected].transform.position, Quaternion.identity) as GameObject;
            smallMeteors.transform.parent = _spawners[metSpawnSelected].transform;
            smallMeteors.SetActive(false);
            _smallMeteorsList.Add(smallMeteors);
        }
        StartCoroutine(SpawnInstance(5));
    }
    public IEnumerator SpawnInstance(int timing)
    {
        yield return new WaitForSeconds(timing);
        if (MeteorController.MetNumOnScreen <= 9)
        {
            MeteorController.TotalMet++;
            for (int i = 0; i < GM.Instance._meteorsList.Count; i++)
            {
                if (GM.Instance._meteorsList[i].activeInHierarchy == false)
                {
                    GM.Instance._meteorsList[i].SetActive(true);
                    break;
                }
            }
            StartCoroutine(SpawnInstance(timing));
        }
        else
        {
            StartCoroutine(SpawnInstance(timing));
        }
    }
    public IEnumerator SpawnInstance(int timing, int a, Vector2 position)
    {
        if (a == 1)
        {
            if (MeteorController.MetNumOnScreen <= 40)
            {
                MeteorController.TotalMet++;
                for (int i = 0; i < GM.Instance._mediumMeteorsList.Count; i++)
                {
                    if (GM.Instance._mediumMeteorsList[i].activeInHierarchy == false)
                    {
                        GM.Instance._mediumMeteorsList[i].transform.position = position;
                        GM.Instance._mediumMeteorsList[i].SetActive(true);
                        GM.Instance._mediumMeteorsList[i + 1].transform.position = position;
                        GM.Instance._mediumMeteorsList[i + 1].SetActive(true);
                        break;
                    }
                }
                StartCoroutine(SpawnInstance(timing));
            }
            else
            {
                StartCoroutine(SpawnInstance(timing));
            }
        }
        else if (a == 2)
        {
            if (MeteorController.MetNumOnScreen <= 40)
            {
                MeteorController.TotalMet++;
                for (int i = 0; i < GM.Instance._smallMeteorsList.Count; i++)
                {
                    if (GM.Instance._smallMeteorsList[i].activeInHierarchy == false)
                    {
                        GM.Instance._smallMeteorsList[i].transform.position = position;
                        GM.Instance._smallMeteorsList[i].SetActive(true);
                        GM.Instance._smallMeteorsList[i + 1].transform.position = position;
                        GM.Instance._smallMeteorsList[i + 1].SetActive(true);
                        break;
                    }
                }
                StartCoroutine(SpawnInstance(timing));
            }
            else
            {
                StartCoroutine(SpawnInstance(timing));
            }
        }
        yield return new WaitForSeconds(timing);
    }
}