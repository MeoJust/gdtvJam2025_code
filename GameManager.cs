using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool IsDesert = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadDesertLevel()
    {
        IsDesert = true;
        SceneManager.LoadScene(1);
    }

    public void LoadIceLevel()
    {
        IsDesert = false;
        SceneManager.LoadScene(1);
    }
}
