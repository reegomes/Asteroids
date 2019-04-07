using UnityEngine;
public class Scroll : MonoBehaviour
{
    public Renderer rendBG;
    void Update()
    {
        Vector2 offset = new Vector2(0.5f * Time.deltaTime, 0);
        rendBG.material.mainTextureOffset += offset;
    }
}