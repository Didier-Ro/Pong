using UnityEngine;

public class BouncySurface : MonoBehaviour
{
    [SerializeField] private float _bounceStrength = default;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Vector2 normal = collision.GetContact(0).normal;
            ball.AddForce(-normal * _bounceStrength); 
        }
    }
}
