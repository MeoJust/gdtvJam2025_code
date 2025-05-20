using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Player _player;
    IA_Player _controls;

    CharacterController _controller;

    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] float _rotSpeed = 10f;

    Vector2 _moveInput;
    Vector3 _moveDir;
    float _verticalVelocity;

    void Start()
    {
        _player = GetComponent<Player>();
        _controls = _player.Controls;
        _controller = GetComponent<CharacterController>();

        _controls.onFoot.move.performed += ctx => _moveInput = ctx.ReadValue<Vector2>();
        _controls.onFoot.move.canceled += ctx => _moveInput = Vector2.zero;
    }

    void Update()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        _moveDir = new Vector3(_moveInput.x, 0, _moveInput.y);
        ApplyGravity();

        if (_moveDir.magnitude > 0)
        {
            _controller.Move(_moveDir * _moveSpeed * Time.deltaTime);
        }
    }

    void Rotate()
    {
        Vector3 lookDir = _player.Aim.GetMousePos() - transform.position;
        lookDir.y = 0;
        lookDir = lookDir.normalized;

        transform.forward = Vector3.Slerp(transform.forward, lookDir, _rotSpeed * Time.deltaTime);
    }

    void ApplyGravity()
    {
        if (!_controller.isGrounded)
        {
            _verticalVelocity -= 9.81f * Time.deltaTime;
        }
        else
        {
            _verticalVelocity = -0.5f;
        }

        _moveDir.y = _verticalVelocity;
    }
}
