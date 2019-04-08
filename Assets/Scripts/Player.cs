using System.Collections;
using UnityEngine;
public class Player : MonoBehaviour
{
    #region Rigidbody
    [SerializeField]
    Rigidbody2D rb;
    #endregion
    #region Status da vida
    [SerializeField]
    public static bool isAlive;
    //Joysticks joy = new Joysticks();
    #endregion
    #region Controle de Camera
    CamAspect camAsp = new CamAspect();
    #endregion
    #region Score, danos e etc
    [SerializeField]
    public static int life;
    private float impact;
    [SerializeField]
    private AudioSource sDeath, sDamage;
    [SerializeField]
    private GameObject gameOver, shield;
    [SerializeField]
    SpriteRenderer sptRender;
    [SerializeField]
    Collider2D col;
    #endregion
    void Start()
    {
        // Vidas
        life = 3;
        // Força do impactor
        impact = 3;
        // Instanciação da Camera
        camAsp.CamStart();
        // Inicia vivo
        isAlive = true;
    }
    void Update()
    {
        // Inputs
        if (isAlive)
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > impact)
        {
            isAlive = false;
            if (life == 0)
            {
                col.enabled = false;
                sptRender.enabled = false;
                sDeath.Play();
                Score.CheckHighScore();
                GameOver();
            }
            else
            {
                LifesUI.RemoveLife();
                col.enabled = false;
                sptRender.enabled = false;
                TakeDamage(1);
                sDamage.Play();
                StartCoroutine(Respawn());
            }
        }
    }
    void TakeDamage(int damage) => life -= damage;
    void GameOver() => gameOver.SetActive(true);
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(3f);
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        sptRender.enabled = true;
        transform.Rotate(Vector2.zero);
        isAlive = true;
        StartCoroutine(Immortality());
    }
    IEnumerator Immortality()
    {
        yield return new WaitForSeconds(3f);
        col.enabled = true;
    }
}