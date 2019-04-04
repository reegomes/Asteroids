using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    [SerializeField]
    GameObject meteor;
    void Start()
    {
        StartCoroutine(Spawn(3));
    }

    void Update()
    {

    }

    IEnumerator Spawn(int timing)
    {
        Instantiate(meteor, Vector2.zero, Quaternion.identity);
        yield return new WaitForSeconds(timing);
        StartCoroutine(Spawn(timing));
    }
}