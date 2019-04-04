using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Rigidbody
    [SerializeField]
    Rigidbody2D rb;
    #endregion
    #region Variaveis de controle
    // Entradas verticais e horizontais
    //[SerializeField]
    //private float vert, hori;
    #endregion
    #region Controle de Camera
    // Cam
    [SerializeField]
    Camera cam;
    private float screenSizeX;
    #endregion

    Joysticks joy = new Joysticks();

    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject bTransform;

    void Start()
    {
        screenSizeX = cam.orthographicSize * cam.aspect;
    }
    void Update()
    {
        // Inputs
        //vert = Joysticks.Vertical;
        //hori = Joysticks.Horizontal;
        joy.InputJoy();
        StartCoroutine(CdFire());

        // Controle de posicionamento
        Vector2 newPos = transform.position;
        if (transform.position.y > cam.orthographicSize + 1)
            newPos.y = -cam.orthographicSize;
        if (transform.position.y < -cam.orthographicSize - 1)
            newPos.y = cam.orthographicSize;
        if (transform.position.x > screenSizeX + 1)
            newPos.x = -screenSizeX;
        if (transform.position.x < -screenSizeX - 1)
            newPos.x = screenSizeX;
        
        transform.position = newPos;
    }
    void FixedUpdate()
    {
        //rb.AddRelativeForce(Vector2.up * vert);
        //rb.AddTorque(-hori * 10);
        rb.AddRelativeForce(Vector2.up * Joysticks.Vertical);
        rb.AddTorque(-Joysticks.Horizontal * 10);
    }
    IEnumerator CdFire()
    {
        yield return new WaitForSeconds(0.1f);
        joy.Fire(bullet, bTransform.transform);
    }
}