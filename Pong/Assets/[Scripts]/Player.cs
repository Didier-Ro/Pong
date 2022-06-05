using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D = default;
    [SerializeField] private float _speed = default;
    private Vector2 _direction = default;

    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _direction = Vector2.down;
        }
        else
        {
            _direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (_direction.sqrMagnitude != 0)
        {
            _rigidBody2D.AddForce(_direction * _speed);
        }
    }
}
