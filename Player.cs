using UnityEngine;

public class Player : MonoBehaviour
{
    public IA_Player Controls { get; private set; }
    public PlayerAim Aim { get; private set; }

    void Awake()
    {
        Controls = new IA_Player();
        Aim = GetComponent<PlayerAim>();
    }

    void OnEnable()
    {
        Controls.Enable();
    }

    void OnDisable()
    {
        Controls.Disable();
    }

}
