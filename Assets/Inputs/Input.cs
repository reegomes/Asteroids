using UnityEngine;
using UnityEngine.Experimental.Input;
public class Input : MonoBehaviour
{
    #region Rigidbody
    [SerializeField]
    private Rigidbody2D rb;
    #endregion
    #region Tiros e propulsor
    [SerializeField]
    private GameObject bullet, bTransform;
    [SerializeField]
    private GameObject rocket;
    #endregion
    #region Variaveis de controle
    [SerializeField]
    private Controls control;
    [SerializeField]
    private InputAction up, right, left;
    private float Vertical { get; set; }
    private float Horizontal { get; set; }
    #endregion
    private void Awake()
    {
        up.performed += context => Vertical = 1;
        up.cancelled += context => Vertical = 0;

        right.performed += context => Horizontal = 1;
        right.cancelled += context => Horizontal = 0;

        left.performed += context => Horizontal = -1;
        left.cancelled += context => Horizontal = 0;
    }
    private void Update()
    {
        if (!GM.isPause)
        {
            rb.AddRelativeForce(Vector2.up * Vertical);
            transform.Rotate(Vector3.forward * Horizontal * Time.deltaTime * -100);
        }

        if (Vertical > 0 && Player.isAlive == true && GM.isPause == false)
        {
            rocket.SetActive(true);
        }
        else
        {
            rocket.SetActive(false);
        }
    }
    private void OnEnable()
    {
        up.Enable();
        right.Enable();
        left.Enable();

        control.Spaceship.Fire.performed += HandleFire;
        control.Spaceship.Fire.Enable();
    }
    private void OnDisable()
    {
        up.Disable();
        right.Disable();
        left.Disable();
    }
    private void HandleFire(InputAction.CallbackContext obj)
    {
        if (!GM.isPause)
        {
            GameObject tBullet = Instantiate(bullet, bTransform.transform.position, bTransform.transform.rotation);
            tBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * 500);
        }
    }
}