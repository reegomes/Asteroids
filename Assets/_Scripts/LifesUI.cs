using UnityEngine;
public class LifesUI : MonoBehaviour
{
    #region Variaveis de controle da UI
    [SerializeField]
    private GameObject[] _lifes;
    private static int _lifeAmount;
    public static int LifeAmount { get => _lifeAmount; set => _lifeAmount = value; }
    #endregion
    private void Start() => _lifeAmount = 3;
    private void Update()
    {
        switch (_lifeAmount)
        {
            case 3:
                _lifes[0].gameObject.SetActive(true);
                _lifes[1].gameObject.SetActive(true);
                _lifes[2].gameObject.SetActive(true);
                break;
            case 2:
                _lifes[0].gameObject.SetActive(true);
                _lifes[1].gameObject.SetActive(true);
                _lifes[2].gameObject.SetActive(false);
                break;
            case 1:
                _lifes[0].gameObject.SetActive(true);
                _lifes[1].gameObject.SetActive(false);
                _lifes[2].gameObject.SetActive(false);
                break;
            case 0:
                _lifes[0].gameObject.SetActive(false);
                _lifes[1].gameObject.SetActive(false);
                _lifes[2].gameObject.SetActive(false);
                break;
            default:
                _lifes[0].gameObject.SetActive(true);
                _lifes[1].gameObject.SetActive(true);
                _lifes[2].gameObject.SetActive(true);
                break;
        }
    }
    public static void RemoveLife()
    {
        LifeAmount -= 1;
    }
    public static void AddLife()
    {
        LifeAmount += 1;
    }
}