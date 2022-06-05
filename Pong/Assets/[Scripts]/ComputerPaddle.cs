using UnityEngine;

public class ComputerPaddle : MonoBehaviour
{
    [SerializeField] private Rigidbody2D ball;
    private Rigidbody2D _rigidBody2D = default;
    [SerializeField] private float speed = default;

    private void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (ball.velocity.x > 0f)
        {
            // Move the paddle in the direction of the ball to track it
            if (ball.position.y > _rigidBody2D.position.y)
            {
                _rigidBody2D.AddForce(Vector2.up * speed);
            }
            else if (ball.position.y < _rigidBody2D.position.y)
            {
                _rigidBody2D.AddForce(Vector2.down * speed);
            }
        }
        else
        {
            if (_rigidBody2D.position.y > 0f)
            {
                _rigidBody2D.AddForce(Vector2.down * speed);
            }
            else if (_rigidBody2D.position.y < 0f)
            {
                _rigidBody2D.AddForce(Vector2.up * speed);
            }
        }
    }
}
