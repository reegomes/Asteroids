using UnityEngine;
public class UfoScript : MonoBehaviour
{
    private const int _valueCon = 3;
    private const int _conPoints = 100;
    private const int _conSeed = 5;
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
        Vector2 rotation = new Vector2(100, 0);
        _rb.AddForce(rotation);
        _rb.AddTorque(_conSeed);
    }
    protected void Update()
    {
        // Controle de posicionamento
        Vector2 newPos = this.transform.position;
        if (this.transform.position.y > CamAspect._cam.orthographicSize + _valueCon)
            DestroyThis();
        if (transform.position.y < -CamAspect._cam.orthographicSize - _valueCon)
            DestroyThis();
        if (transform.position.x > camAsp.ScreenSizeX + _valueCon)
            DestroyThis();
        if (transform.position.x < -camAsp.ScreenSizeX - _valueCon)
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
        AddScore(_conPoints);
        Destroy(this.gameObject);
    }
    void AddScore(int points)
    {
        Score.CurrentScore += points;
    }
}