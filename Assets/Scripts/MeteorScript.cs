using UnityEngine;
public class MeteorScript : MonoBehaviour
{
    [SerializeField]
    private float speed, rotation;
    [SerializeField]
    Rigidbody2D rb;
    CamAspect camAsp = new CamAspect();
    void Start()
    {
        // Instanciação da Camera
        camAsp.CamStart();

        // Controles de velocidade e rotacao
        speed = Random.Range(1, 10);
        Vector2 rotation = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
        rb.AddForce(rotation);
        rb.AddTorque(speed);

        // Adiciona o numero de meteoros no controlador
        MeteorController.metNumOnScreen++;
    }
    void Update()
    {
        // Controle de posicionamento
        Vector2 newPos = this.transform.position;
        if (this.transform.position.y > CamAspect.cam.orthographicSize + 1)
            newPos.y = -CamAspect.cam.orthographicSize;
        if (transform.position.y < -CamAspect.cam.orthographicSize - 1)
            newPos.y = CamAspect.cam.orthographicSize;
        if (transform.position.x > camAsp.ScreenSizeX + 1)
            newPos.x = -camAsp.ScreenSizeX;
        if (transform.position.x < -camAsp.ScreenSizeX - 1)
            newPos.x = camAsp.ScreenSizeX;

        transform.position = newPos;
    }
}