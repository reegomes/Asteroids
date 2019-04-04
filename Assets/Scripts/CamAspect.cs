using UnityEngine;

public class CamAspect : MonoBehaviour
{
    #region Controle de Camera
    // Cam
    [SerializeField]
    public static Camera cam;
    public float screenSizeX;
    #endregion
    public void CamStart()
    {
        cam = Camera.main;
        screenSizeX = cam.orthographicSize * cam.aspect;
    }
}