using UnityEngine;
public class Bullet : MonoBehaviour
{
    private const float _time = 5f;
    private void Start()
    {
        Destroy(this.gameObject, _time);
    }
}