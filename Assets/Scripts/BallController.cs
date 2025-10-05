using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class BallController : MonoBehaviour
{
    public float speed = 8f;

    Rigidbody2D rb;
    Vector3 startPos;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        rb.gravityScale = 0f;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void Start()
    {
        Launch(Random.value > 0.5f); // lanza a un lado al azar
    }

    public void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPos;
    }

    public void Launch(bool toRight)
    {
        float y = Random.Range(-0.6f, 0.6f);
        Vector2 dir = new Vector2(toRight ? 1f : -1f, y).normalized;
        rb.velocity = dir * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Paddle"))
        {
            float y = (transform.position.y - col.transform.position.y) / col.collider.bounds.extents.y;
            Vector2 dir = new Vector2(Mathf.Sign(rb.velocity.x), y).normalized;
            rb.velocity = dir * speed;
        }
    }
}
