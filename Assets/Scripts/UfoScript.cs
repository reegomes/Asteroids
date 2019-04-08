using UnityEngine;
public class UfoScript : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Rigidbody2D _rb;
    CamAspect camAsp = new CamAspect();
    protected void Start()
    {
        // Instanciação da Camera
        camAsp.CamStart();

        // Controles de velocidade e rotacao
        _speed = 5;
        Vector2 rotation = new Vector2(100, 0);
        _rb.AddForce(rotation);
        _rb.AddTorque(_speed);
    }
    protected void Update()
    {
        // Controle de posicionamento
        Vector2 newPos = this.transform.position;
        if (this.transform.position.y > CamAspect._cam.orthographicSize + 3)
            DestroyThis();
        if (transform.position.y < -CamAspect._cam.orthographicSize - 3)
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
        Score.AliensKilled++;
        AddScore(100);
        Destroy(this.gameObject);
    }
    void AddScore(int points) => Score.CurrentScore += points;
}