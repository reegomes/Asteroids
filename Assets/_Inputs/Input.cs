using UnityEngine;
using UnityEngine.Experimental.Input;
public class Input : MonoBehaviour
{
    #region Rigidbody
    [SerializeField]
    private Rigidbody2D _rb;
    #endregion
    #region Tiros e propulsor
    [SerializeField]
    private GameObject _bullet, _bTransform;
    [SerializeField]
    private GameObject _rocket;
    #endregion
    #region Variaveis de controle
    [SerializeField]
    private Controls _control;
    [SerializeField]
    private InputAction _up, _right, _left;
    private float Vertical { get; set; }
    private float Horizontal { get; set; }
    #endregion
    private void Awake()
    {
        _up.performed += context => Vertical = 1;
        _up.cancelled += context => Vertical = 0;

        _right.performed += context => Horizontal = 1;
        _right.cancelled += context => Horizontal = 0;

        _left.performed += context => Horizontal = -1;
        _left.cancelled += context => Horizontal = 0;
    }
    private void Update()
    {
        if (!GameManager.IsPause)
        {
            _rb.AddRelativeForce(Vector2.up * Vertical);
            transform.Rotate(Vector3.forward * Horizontal * Time.deltaTime * -100);
        }

        if (Vertical > 0 && Player.IsAlive == true && GameManager.IsPause == false)
        {
            _rocket.SetActive(true);
        }
        else
        {
            _rocket.SetActive(false);
        }
    }
    private void OnEnable()
    {
        _up.Enable();
        _right.Enable();
        _left.Enable();

        _control.Spaceship.Fire.performed += HandleFire;
        _control.Spaceship.Fire.Enable();
    }
    private void OnDisable()
    {
        _up.Disable();
        _right.Disable();
        _left.Disable();
    }
    private void HandleFire(InputAction.CallbackContext obj)
    {
        if (!GameManager.IsPause && Player.IsAlive)
        {
            GameObject tBullet = Instantiate(_bullet, _bTransform.transform.position, _bTransform.transform.rotation);
            tBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * 500);
        }
    }
}