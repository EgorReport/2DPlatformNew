using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForse;

    private Transform _transform;
    private Rigidbody2D _rb;

    [SerializeField] private MoveState _currentStateMove;
    [SerializeField] private TurnState _currentStateTurn;

    private enum MoveState
    {
        Idle,
        Walk,
        Jump,
    }
    enum TurnState
    {
        Left,
        Right
    }

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody2D>();

        Idle();
        _currentStateTurn = transform.localScale.x > 0 ? TurnState.Right : TurnState.Left;
    }

    private void FixedUpdate()
    {
        if (_currentStateMove == MoveState.Jump)
        {
            if (_rb.velocity.y == 0)
            {
                Idle();
            }
        }

        if (_rb.velocity.y < 0 && _currentStateMove == MoveState.Walk)
        {
            Idle();
        }

        if (_currentStateMove == MoveState.Walk)
        {
            _rb.velocity = ((_currentStateTurn == TurnState.Right ? Vector2.right : -Vector2.right) * _speed);
            Idle();
        }
    }

    private void Idle()
    {
        _currentStateMove = MoveState.Idle;
    }

    public void MoveRight()
    {
        if (_currentStateMove != MoveState.Jump)
        {
            _currentStateMove = MoveState.Walk;
            if (_currentStateTurn == TurnState.Left)
            {
                _transform.localScale = new Vector3(-_transform.localScale.x, _transform.localScale.y, transform.localScale.z);
                _currentStateTurn = TurnState.Right;
            }
        }
    }

    public void MoveLeft()
    {
        if (_currentStateMove != MoveState.Jump)
        {
            _currentStateMove = MoveState.Walk;
            if (_currentStateTurn == TurnState.Right)
            {
                _transform.localScale = new Vector3(-_transform.localScale.x, _transform.localScale.y, transform.localScale.z);
                _currentStateTurn = TurnState.Left;
            }
        }
    }

    public void Jump()
    {
        if (_currentStateMove != MoveState.Jump)
        {
            _rb.velocity +=Vector2 .up*_jumpForse;
            _currentStateMove = MoveState.Jump;
        }
    }
}

