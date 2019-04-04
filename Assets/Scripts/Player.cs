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
    #region em teste
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    GameObject bTransform;

    [SerializeField]
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
        yield return new WaitForSeconds(1f);
        joy.Fire(bullet, bTransform.transform);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > impact)
        {
            Debug.Log("Death");
        }
    }
}