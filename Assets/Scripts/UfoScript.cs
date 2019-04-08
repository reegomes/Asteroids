using UnityEngine;
public class UfoScript : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    Rigidbody2D rb;
    CamAspect camAsp = new CamAspect();
    protected void Start()
    {
        // Instanciação da Camera
        camAsp.CamStart();

        // Controles de velocidade e rotacao
        speed = 5;
        Vector2 rotation = new Vector2(100, 0);
        rb.AddForce(rotation);
        rb.AddTorque(speed);
    }
    protected void Update()
    {
        // Controle de posicionamento
        Vector2 newPos = this.transform.position;
        if (this.transform.position.y > CamAspect.cam.orthographicSize + 3)
            DestroyThis();
        if (transform.position.y < -CamAspect.cam.orthographicSize - 3)
            DestroyThis();
        if (transform.position.x > camAsp.ScreenSizeX + 3)
            DestroyThis();
        if (transform.position.x < -camAsp.ScreenSizeX - 1)
            DestroyThis();

        transform.position = newPos;
    }
    void DestroyThis()
    {
        MeteorController.TotalUfo--;
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Score.aliensKilled++;
        AddScore(100);
        Destroy(this.gameObject);
    }
    void AddScore(int points) => Score.score += points;
}