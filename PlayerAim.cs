using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    Player _player;
    IA_Player _controls;

    [SerializeField] LayerMask _aimLayerMask;
    [SerializeField] Transform _aimGO;

    Vector2 _aimInput;
    Vector3 _aimDir;

    RaycastHit _lastKnownAimPoint;

    void Start()
    {
        _player = GetComponent<Player>();
        _controls = _player.Controls;

        _controls.onFoot.aim.performed += ctx => _aimInput = ctx.ReadValue<Vector2>();
        _controls.onFoot.aim.canceled += ctx => _aimInput = Vector2.zero;
    }

    void Update()
    {
        _aimGO.position = new Vector3(GetMousePos().x, transform.position.y + 1.5f, GetMousePos().z);
    }

    public Vector3 GetMousePos()
    {
        Ray ray = Camera.main.ScreenPointToRay(_aimInput);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _aimLayerMask))
        {
            _lastKnownAimPoint = hit;
            return hit.point;
        }
        return _lastKnownAimPoint.point;
    }

    public Transform GetAimPoint()
    {
        return _lastKnownAimPoint.transform;
    }
}
