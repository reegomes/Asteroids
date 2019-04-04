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

    public byte meteorSize;

    void Start()
    {
        int swit = Random.Range(0, 2);

        switch (swit)
        {
            case 0:
                meteorsBrown brownRnd = (meteorsBrown)Random.Range(0, 3);
                this.meteorRenderer.sprite = atlas.GetSprite(brownRnd.ToString());
                int brownValue = (int)brownRnd;
                
                if (brownValue >= 0 && brownValue <= 2)
                {
                    SetSize(1);
                }
                else if (brownValue >= 3 && brownValue <= 5)
                {
                    SetSize(2);
                }
                else
                {
                    SetSize(3);
                }
                    break;
            case 1:
                meteorsGrey grayRnd = (meteorsGrey)Random.Range(0, 3);
                this.meteorRenderer.sprite = atlas.GetSprite(grayRnd.ToString());
                
                break;
            default:
                break;
        }
    }
    public void SetSize(byte size)
    {
        this.meteorSize = size;
    }
}