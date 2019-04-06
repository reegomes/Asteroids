using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifesUI : MonoBehaviour
{
    [SerializeField]
    GameObject[] Lifes;
    private static int lifeAmount;

    public static int LifeAmount { get => lifeAmount; set => lifeAmount = value; }

    private void Start()
    {
        lifeAmount = 3;
    }
    private void Update()
    {
        switch (lifeAmount)
        {
            case 3:
                Lifes[0].gameObject.SetActive(true);
                Lifes[1].gameObject.SetActive(true);
                Lifes[2].gameObject.SetActive(true);
                break;
            case 2:
                Lifes[0].gameObject.SetActive(true);
                Lifes[1].gameObject.SetActive(true);
                Lifes[2].gameObject.SetActive(false);
                break;
            case 1:
                Lifes[0].gameObject.SetActive(true);
                Lifes[1].gameObject.SetActive(false);
                Lifes[2].gameObject.SetActive(false);
                break;
            case 0:
                Lifes[0].gameObject.SetActive(false);
                Lifes[1].gameObject.SetActive(false);
                Lifes[2].gameObject.SetActive(false);
                break;
            default:
                Lifes[0].gameObject.SetActive(true);
                Lifes[1].gameObject.SetActive(true);
                Lifes[2].gameObject.SetActive(true);
                break;
        }
    }
    public static void RemoveLife() => LifeAmount -= 1;
    public static void AddLife() => LifeAmount += 1;
}
