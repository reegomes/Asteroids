using System.Collections;
using UnityEngine;
public class Player : MonoBehaviour
{
    #region Rigidbody
    [SerializeField]
    private Rigidbody2D _rb;
    #endregion
    #region Status da vida
    public static bool IsAlive;
    #endregion
    #region Controle de Camera
    CamAspect camAsp = new CamAspect();
    #endregion
    #region Score, danos e etc
    [SerializeField]
    public static int Life;
    private float _impact;
    [SerializeField]
    private AudioSource _sDeath, _sDamage;
    [SerializeField]
    private GameObject _gameOver, _shield;
    [SerializeField]
    private SpriteRenderer _sptRender;
    [SerializeField]
    private Collider2D _col;
    #endregion
    void Start()
    {
        // Vidas
        Life = 3;
        // Força do impactor
        _impact = 3;
        // Instanciação da Camera
        camAsp.CamStart();
        // Inicia vivo
        IsAlive = true;
    }
    void Update()
    {
        // Inputs
        if (IsAlive)
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > _impact)
        {
            IsAlive = false;
            if (Life == 0)
            {
                _col.enabled = false;
                _sptRender.enabled = false;
                _sDeath.Play();
                Score.CheckHighScore();
                GameOver();
            }
            else
            {
                LifesUI.RemoveLife();
                _col.enabled = false;
                _sptRender.enabled = false;
                TakeDamage(1);
                _sDamage.Play();
                StartCoroutine(Respawn());
            }
        }
    }
    void TakeDamage(int damage) => Life -= damage;
    void GameOver() => _gameOver.SetActive(true);
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(3f);
        _rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        _sptRender.enabled = true;
        transform.Rotate(Vector2.zero);
        IsAlive = true;
        StartCoroutine(Immortality());
    }
    IEnumerator Immortality()
    {
        yield return new WaitForSeconds(3f);
        _col.enabled = true;
    }
}