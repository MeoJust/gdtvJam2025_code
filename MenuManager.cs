using UnityEngine;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    [SerializeField] Button _desertLevelBTN;
    [SerializeField] Button _iceLevelBTN;

    void Start()
    {
        _desertLevelBTN.onClick.AddListener(GameManager.Instance.LoadDesertLevel);
        _iceLevelBTN.onClick.AddListener(GameManager.Instance.LoadIceLevel);
    }
}
