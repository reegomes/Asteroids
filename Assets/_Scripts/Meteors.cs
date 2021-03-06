﻿using UnityEngine;
using UnityEngine.U2D;
public class Meteors : MonoBehaviour
{

    #region Geracao e opcoes dos meteoros
    [SerializeField]
    private SpriteAtlas _atlas;
    [SerializeField]
    private SpriteRenderer _meteorRenderer;
    public byte MeteorSize;
    private const int _bigPoints = 100, _medPoints = 250, _smallPoints = 500;
    #endregion
    private void OnEnable()
    {
        //Selecão de Sprites
        if (MeteorSize == 1)
        {
            MeteorsBrown brownRnd = (MeteorsBrown)Random.Range(0, 3);
            this._meteorRenderer.sprite = _atlas.GetSprite(brownRnd.ToString());
        }
        else if (MeteorSize == 2)
        {
            MeteorsBrown brownRnd = (MeteorsBrown)Random.Range(4, 5);
            this._meteorRenderer.sprite = _atlas.GetSprite(brownRnd.ToString());
        }
        else if (MeteorSize == 3)
        {
            MeteorsBrown brownRnd = (MeteorsBrown)Random.Range(6, 7);
            this._meteorRenderer.sprite = _atlas.GetSprite(brownRnd.ToString());
        }
        else if (MeteorSize == 4)
        {
            MeteorsBrown brownRnd = (MeteorsBrown)Random.Range(8, 9);
            this._meteorRenderer.sprite = _atlas.GetSprite(brownRnd.ToString());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if (this.MeteorSize == 1)
        {
            AddScore(_bigPoints);
            MeteorController.MetNumOnScreen--;
            StartCoroutine(GameManager.Instance.SpawnInstance(1, MeteorSize, this.transform.position));
            OnDisable();
        }
        else if (this.MeteorSize == 2)
        {
            AddScore(_medPoints);
            MeteorController.MetNumOnScreen--;
            StartCoroutine(GameManager.Instance.SpawnInstance(1, MeteorSize, this.transform.position));
            OnDisable();
        }
        else if (this.MeteorSize == 3)
        {
            AddScore(_smallPoints);
            MeteorController.MetNumOnScreen--;
            OnDisable();
        }
        else if (this.MeteorSize == 4)
        {
            // Muito dificil acertar, mas quem sabe num modo insano
            //AddScore(1500);
            //MeteorController.MetNumOnScreen--;
            //OnDisable();         
        }
    }
    private void OnDisable()
    {
        this.gameObject.SetActive(false);
    }
    void AddScore(int points)
    {
        Score.CurrentScore += points;
    }
}