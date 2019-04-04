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
    [SerializeField]
    GameObject mMet, sMet, tMet;
    #endregion
    #region Score

    #endregion
    private void Start()
    {
        int color = Random.Range(0, 2);
        Debug.Log(color);

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
            GameObject meteor1 = Instantiate(mMet, transform.position, transform.rotation);
            GameObject meteor2 = Instantiate(mMet, transform.position, transform.rotation);
            AddScore(100);
            Destroy(this.gameObject);
        }
        else if (this.meteorSize == 2)
        {
            GameObject meteor1 = Instantiate(sMet, transform.position, transform.rotation);
            GameObject meteor2 = Instantiate(sMet, transform.position, transform.rotation);
            AddScore(250);
            Destroy(this.gameObject);
        }
        else if (this.meteorSize == 3)
        {
            //GameObject meteor1 = Instantiate(tMet, transform.position, transform.rotation);
            //GameObject meteor2 = Instantiate(tMet, transform.position, transform.rotation);
            AddScore(500);
            Destroy(this.gameObject);
        }
        else if (this.meteorSize == 4)
        {
            // Muito dificil acertar;
        }
    }
    void AddScore(int points)
    {
        Score.score += points;
    }
}