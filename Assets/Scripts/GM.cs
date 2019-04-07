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

    public static bool isPause { get; set; }
    private void Awake() => _instance = this;
    private void Start() => isPause = false;
}