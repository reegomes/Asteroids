using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{

    [SerializeField]
    private float speed, rotation;
    [SerializeField]
    Rigidbody2D rb;

    CamAspect camAsp = new CamAspect();

    Meteors sizeM = new Meteors();

    void Start()
    {
        // Instanciação da Camera
        camAsp.CamStart();

        // Controles de velocidade e rotacao
        speed = Random.Range(1, 100);
        Vector2 rotation = new Vector2(Random.Range(-100, 100), Random.Range(-100, 100));
        rb.AddForce(rotation);
        rb.AddTorque(speed);

        
    }

    void Update()
    {
        
        // Controle de posicionamento
        Vector2 newPos = this.transform.position;
        if (this.transform.position.y > CamAspect.cam.orthographicSize + 1)
            newPos.y = -CamAspect.cam.orthographicSize;
        if (transform.position.y < -CamAspect.cam.orthographicSize - 1)
            newPos.y = CamAspect.cam.orthographicSize;
        if (transform.position.x > camAsp.screenSizeX + 1)
            newPos.x = -camAsp.screenSizeX;
        if (transform.position.x < -camAsp.screenSizeX - 1)
            newPos.x = camAsp.screenSizeX;

        transform.position = newPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int size = sizeM.meteorSize;
        if (size == 0)
        {
            Debug.Log("Size 0");
        } 
        else if(size == 1)
        {
            Debug.Log("Size 1");
        }
        Destroy(collision.gameObject);
    }
}