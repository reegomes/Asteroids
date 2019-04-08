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
    public static bool isPause { get; set; }
    #endregion
    #region Instanciação dos meteoros
    public GameObject meteorPrefab, mediumMeteorPrefab, smallMeteorPrefab;
    public int meteorsToSpawn = 30;
    public GameObject[] spawners;
    public List<GameObject> meteorsList = new List<GameObject>();
    public List<GameObject> mediumMeteorsList = new List<GameObject>();
    public List<GameObject> smallMeteorsList = new List<GameObject>();
    #endregion
    private void Awake() => _instance = this;
    private void Start()
    {
        isPause = false;
        for (int i = 0; i < meteorsToSpawn; i++)
        {
            int metSpawnSelected = Random.Range(0, spawners.Length);

            // Container grande
            GameObject meteors = Instantiate(meteorPrefab, spawners[metSpawnSelected].transform.position, Quaternion.identity) as GameObject;
            meteors.transform.parent = spawners[metSpawnSelected].transform;
            meteors.SetActive(false);
            meteorsList.Add(meteors);
            // Container médio
            GameObject mediumMeteors = Instantiate(mediumMeteorPrefab, spawners[metSpawnSelected].transform.position, Quaternion.identity) as GameObject;
            mediumMeteors.transform.parent = spawners[metSpawnSelected].transform;
            mediumMeteors.SetActive(false);
            mediumMeteorsList.Add(mediumMeteors);
            // Container pequeno
            GameObject smallMeteors = Instantiate(smallMeteorPrefab, spawners[metSpawnSelected].transform.position, Quaternion.identity) as GameObject;
            smallMeteors.transform.parent = spawners[metSpawnSelected].transform;
            smallMeteors.SetActive(false);
            smallMeteorsList.Add(smallMeteors);
        }
        StartCoroutine(SpawnInstance(5));
    }
    public IEnumerator SpawnInstance(int timing)
    {
        yield return new WaitForSeconds(timing);
        if (MeteorController.metNumOnScreen <= 9)
        {
            MeteorController.totalMet++;
            for (int i = 0; i < GM.Instance.meteorsList.Count; i++)
            {
                if (GM.Instance.meteorsList[i].activeInHierarchy == false)
                {
                    GM.Instance.meteorsList[i].SetActive(true);
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
    //Instanciar os meteoros menores
    public IEnumerator SpawnInstance(int timing, int a, Vector2 position)
    {
        if (a == 1)
        {
            if (MeteorController.metNumOnScreen <= 40)
            {
                MeteorController.totalMet++;
                for (int i = 0; i < GM.Instance.mediumMeteorsList.Count; i++)
                {
                    if (GM.Instance.mediumMeteorsList[i].activeInHierarchy == false)
                    {
                        GM.Instance.mediumMeteorsList[i].transform.position = position;
                        GM.Instance.mediumMeteorsList[i].SetActive(true);
                        GM.Instance.mediumMeteorsList[i + 1].transform.position = position;
                        GM.Instance.mediumMeteorsList[i + 1].SetActive(true);
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
            if (MeteorController.metNumOnScreen <= 40)
            {
                MeteorController.totalMet++;
                for (int i = 0; i < GM.Instance.smallMeteorsList.Count; i++)
                {
                    if (GM.Instance.smallMeteorsList[i].activeInHierarchy == false)
                    {
                        GM.Instance.smallMeteorsList[i].transform.position = position;
                        GM.Instance.smallMeteorsList[i].SetActive(true);
                        GM.Instance.smallMeteorsList[i + 1].transform.position = position;
                        GM.Instance.smallMeteorsList[i + 1].SetActive(true);
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