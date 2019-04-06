﻿using System.Collections;
using UnityEngine;
public class UfoRed : MonoBehaviour
{
    GameObject tPlayer;
    [SerializeField]
    Rigidbody2D rb;
    CamAspect camAsp = new CamAspect();
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    GameObject bTransform;
    void Start()
    {
        // Instanciação da Camera
        camAsp.CamStart();

        // Controles de velocidade
        Vector2 speed = new Vector2(50, 0);
        rb.AddForce(speed);

        // Tiros
        StartCoroutine(Fire());

        // Procura personagem
        tPlayer = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        // Controle de posicionamento
        Vector2 newPos = this.transform.position;
        if (this.transform.position.y > CamAspect.cam.orthographicSize + 3)
        {
            MeteorController.TotalUfo--;
            Destroy(this.gameObject);
        }
        if (transform.position.y < -CamAspect.cam.orthographicSize - 3)
        {
            MeteorController.TotalUfo--;
            Destroy(this.gameObject);
        }
        if (transform.position.x > camAsp.ScreenSizeX + 3)
        {
            MeteorController.TotalUfo--;
            Destroy(this.gameObject);
        }
        if (transform.position.x < -camAsp.ScreenSizeX - 1)
        {
            MeteorController.TotalUfo--;
            Destroy(this.gameObject);
        }

        transform.position = newPos;

        LookAt();
    }
    void LookAt()
    {
        Vector3 targetPos = tPlayer.gameObject.transform.position;
        Vector3 thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        float offset = 0;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
    }
    IEnumerator Fire()
    {
        GameObject tBullet = Instantiate(bullet, bTransform.transform.position, bTransform.transform.rotation);
        tBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * 300);
        yield return new WaitForSeconds(2);
        StartCoroutine(Fire());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AddScore(1000);
        Destroy(this.gameObject);
    }
    void AddScore(int points) => Score.score += points;
}