using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Meteors : MonoBehaviour
{
    [SerializeField]
    private meteorsBrown currentType;
    private meteorsBrown lastType;
    [SerializeField]
    private SpriteAtlas atlas;
    [SerializeField]
    SpriteRenderer meteorRenderer;
    // Start is called before the first frame update
    void Start()
    {
        int swit = Random.Range(0, 2);

        switch (swit)
        {
            case 0:
                meteorsBrown brownRnd = (meteorsBrown)Random.Range(0, 3);
                this.meteorRenderer.sprite = atlas.GetSprite(brownRnd.ToString());
                break;
            case 1:
                meteorsGrey grayRnd = (meteorsGrey)Random.Range(0, 3);
                this.meteorRenderer.sprite = atlas.GetSprite(grayRnd.ToString());
                break;
            default:
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        ChangeSprite();
    }
    void ChangeSprite()
    {
        if(currentType != lastType)
        {
            meteorRenderer.sprite = atlas.GetSprite(currentType.ToString());

            lastType = currentType;
        }
    }
}
