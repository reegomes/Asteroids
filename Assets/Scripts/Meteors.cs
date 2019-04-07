using UnityEngine;
using UnityEngine.U2D;
public class Meteors : MonoBehaviour
{
    #region Geracao e opcoes dos meteoros
    [SerializeField]
    private SpriteAtlas atlas;
    [SerializeField]
    SpriteRenderer meteorRenderer;
    public byte meteorSize;
    #endregion
    private void Start()
    {
        //Selecão de Sprites
        if (meteorSize == 1)
        {
            MeteorsBrown brownRnd = (MeteorsBrown)Random.Range(0, 3);
            this.meteorRenderer.sprite = atlas.GetSprite(brownRnd.ToString());
        }
        else if (meteorSize == 2)
        {
            MeteorsBrown brownRnd = (MeteorsBrown)Random.Range(4, 5);
            this.meteorRenderer.sprite = atlas.GetSprite(brownRnd.ToString());
        }
        else if (meteorSize == 3)
        {
            MeteorsBrown brownRnd = (MeteorsBrown)Random.Range(6, 7);
            this.meteorRenderer.sprite = atlas.GetSprite(brownRnd.ToString());
        }
        else if (meteorSize == 4)
        {
            MeteorsBrown brownRnd = (MeteorsBrown)Random.Range(8, 9);
            this.meteorRenderer.sprite = atlas.GetSprite(brownRnd.ToString());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if (this.meteorSize == 1)
        {
            AddScore(100);
            MeteorController.metNumOnScreen--;

            StartCoroutine(GM.Instance.SpawnInstance(1, meteorSize, transform.position));
            OnDisable();
        }
        else if (this.meteorSize == 2)
        {
            AddScore(250);
            MeteorController.metNumOnScreen--;

            StartCoroutine(GM.Instance.SpawnInstance(1, meteorSize, transform.position));
            OnDisable();
        }
        else if (this.meteorSize == 3)
        {
            AddScore(500);
            MeteorController.metNumOnScreen--;

            OnDisable();
        }
        else if (this.meteorSize == 4)
        {
            // Muito dificil acertar, mas quem sabe num modo insano
            //AddScore(1500);
            //MeteorController.MetNumOnScreen--;
            //OnDisable();         
        }
    }
    private void OnDisable() => this.gameObject.SetActive(false);
    void AddScore(int points) => Score.score += points;
}