using UnityEngine;
public class CamAspect : MonoBehaviour
{
    #region Controle de Camera
    // Cam
    [SerializeField]
    public static Camera _cam;
    public float ScreenSizeX;
    #endregion
    public void CamStart()
    {
        _cam = Camera.main;
        ScreenSizeX = _cam.orthographicSize * _cam.aspect;
    }
}