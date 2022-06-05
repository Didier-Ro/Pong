using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D = default;
    [SerializeField] private float _speed = 100f;
    [SerializeField] private AudioClip _bounce = default;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        ResetBall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.Instance.SetAudioClip(_bounce, 1f);

        if (collision.gameObject.CompareTag("LeftWall"))
        {
            GameManager.Instance.ComputerScore();
        }
        if (collision.gameObject.CompareTag("RightWall"))
        {
            GameManager.Instance.PlayerScore();
        }
    }

    public void ResetBall()
    {
        _rigidbody2D.position = Vector3.zero;
        _rigidbody2D.velocity = Vector3.zero;

        AddStartingForce();
    }

    private void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(1.0f, 0.5f);

        Vector2 direction = new Vector2(x, y);
        _rigidbody2D.AddForce(direction * _speed);
    }

    public void AddForce(Vector2 force)
    {
        _rigidbody2D.AddForce(force);
    }
}
