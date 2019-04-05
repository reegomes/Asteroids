using UnityEngine;

public class CamAspect : MonoBehaviour
{
    #region Controle de Camera
    // Cam
    [SerializeField]
    public static Camera cam;
    public float ScreenSizeX;
    #endregion
    public void CamStart()
    {
        cam = Camera.main;
        ScreenSizeX = cam.orthographicSize * cam.aspect;
    }
}