using UnityEngine;
public class Joysticks : MonoBehaviour
{
    #region Variaveis de controle
    // Entradas verticais e horizontais
    public static float Vertical { get; set; }
    public static float Horizontal { get; set; }
    #endregion
    public void InputJoy()
    {
        // Inputs
        Vertical = Input.GetAxisRaw("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
    }
    public void Fire(GameObject bullet, Transform tf)
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            GameObject tBullet = Instantiate(bullet, tf.position, tf.rotation);
            tBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * 500);
        }
    }
}