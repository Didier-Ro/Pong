using UnityEngine;

public class Paddle : MonoBehaviour
{
    protected Rigidbody2D _rigidBody2D = default;
    public float _speed = 10f;

    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }
}
