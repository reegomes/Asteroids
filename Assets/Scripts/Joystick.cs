using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Joysticks : MonoBehaviour
{
    #region Variaveis de controle
    // Entradas verticais e horizontais
    public static float Vertical { get; set; }
    public static float Horizontal { get; set; }
    #endregion

    //[SerializeField]
    //private GameObject bullet;


    public void InputJoy()
    {
        // Inputs
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
    }
    public void Fire(GameObject bullet, Transform tf)
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            //GameObject tBullet = Instantiate(bullet, tf.position, Quaternion.identity);
            GameObject tBullet = Instantiate(bullet, tf.position, tf.rotation);
            tBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * 50);
            
        }
            

        //Instantiate(bullet, tf.position, tf.rotation);
        //Instantiate(bullet, transform.position, Quaternion.identity);
    }
}