using System.Collections;
using UnityEngine;
public class Player : MonoBehaviour
{
    #region Rigidbody
    [SerializeField]
    Rigidbody2D rb;
    #endregion
    #region Variaveis de controle
    Joysticks joy = new Joysticks();
    #endregion
    #region Controle de Camera
    CamAspect camAsp = new CamAspect();
    #endregion
    #region Tiros
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    GameObject bTransform;
    #endregion
    #region Score, danos e etc
    [SerializeField]
    private int life;
    private float impact;
    #endregion

    void Start()
    {
        // Instanciação da Camera
        camAsp.CamStart();
    }
    void Update()
    {
        // Inputs
        joy.InputJoy();
        StartCoroutine(CdFire());

        // Controle de posicionamento
        Vector2 newPos = this.transform.position;
        if (this.transform.position.y > CamAspect.cam.orthographicSize + 1)
            newPos.y = -CamAspect.cam.orthographicSize;
        if (transform.position.y < -CamAspect.cam.orthographicSize - 1)
            newPos.y = CamAspect.cam.orthographicSize;
        if (transform.position.x > camAsp.screenSizeX + 1)
            newPos.x = -camAsp.screenSizeX;
        if (transform.position.x < -camAsp.screenSizeX - 1)
            newPos.x = camAsp.screenSizeX;

        transform.position = newPos;
    }
    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector2.up * Joysticks.Vertical);
        transform.Rotate(Vector3.forward * Joysticks.Horizontal * Time.deltaTime * -100);
    }
    IEnumerator CdFire()
    {
        joy.Fire(bullet, bTransform.transform);
        yield return new WaitForSeconds(1f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > impact)
        {
            life--;
        }
    }
}