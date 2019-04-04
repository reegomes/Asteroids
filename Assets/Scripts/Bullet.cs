using UnityEngine;
public class Bullet : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 11f);
    }
}