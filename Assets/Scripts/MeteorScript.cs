using UnityEngine;
public class MeteorScript : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Rigidbody2D _rb;
    CamAspect camAsp = new CamAspect();
    private void OnEnable()
    {
        // Instanciação da Camera
        camAsp.CamStart();

        // Controles de velocidade e rotacao
        _speed = Random.Range(1, 10);
        Vector2 rotation = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
        _rb.AddForce(rotation);
        _rb.AddTorque(_speed);

        // Adiciona o numero de meteoros no controlador
        MeteorController.MetNumOnScreen++;
    }
    void Update()
    {
        // Controle de posicionamento
        Vector2 newPos = this.transform.position;
        if (this.transform.position.y > CamAspect._cam.orthographicSize + 1)
            newPos.y = -CamAspect._cam.orthographicSize;
        if (transform.position.y < -CamAspect._cam.orthographicSize - 1)
            newPos.y = CamAspect._cam.orthographicSize;
        if (transform.position.x > camAsp.ScreenSizeX + 1)
            newPos.x = -camAsp.ScreenSizeX;
        if (transform.position.x < -camAsp.ScreenSizeX - 1)
            newPos.x = camAsp.ScreenSizeX;

        transform.position = newPos;
    }
}