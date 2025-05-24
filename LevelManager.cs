using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject _desertIsland;
    [SerializeField] GameObject _iceIsland;

    void Awake()
    {
        if (GameManager.Instance)
        {
            _desertIsland.SetActive(GameManager.Instance.IsDesert);
            _iceIsland.SetActive(!GameManager.Instance.IsDesert);
        }
    }
}
