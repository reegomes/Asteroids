using System.Collections;
using UnityEngine;
public class UfoRed : MonoBehaviour
{
    private GameObject _tPlayer;
    [SerializeField]
    private Rigidbody2D _rb;
    CamAspect camAsp = new CamAspect();
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private GameObject _bTransform;
    void Start()
    {
        // Instanciação da Camera
        camAsp.CamStart();

        // Controles de velocidade
        Vector2 speed = new Vector2(50, 0);
        _rb.AddForce(speed);

        // Tiros
        StartCoroutine(Fire());

        // Procura personagem
        _tPlayer = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
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

        LookAt();
    }
    void DestroyThis()
    {
        MeteorController.TotalUfo--;
        Destroy(this.gameObject);
    }
    void LookAt()
    {
        Vector3 targetPos = _tPlayer.gameObject.transform.position;
        Vector3 thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        float offset = 0;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
    }
    IEnumerator Fire()
    {
        GameObject tBullet = Instantiate(_bullet, _bTransform.transform.position, _bTransform.transform.rotation);
        tBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * 300);
        yield return new WaitForSeconds(2);
        StartCoroutine(Fire());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AddScore(1000);
        Score.AliensKilled++;
        Destroy(this.gameObject);
    }
    void AddScore(int points) => Score.CurrentScore += points;
}