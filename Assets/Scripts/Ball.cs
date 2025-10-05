using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 8f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.freezeRotation = true;
        Lanzar();
    }

    public void Reiniciar(bool derecha)
    {
        transform.position = Vector3.zero;
        Vector2 dir = derecha ? Vector2.right : Vector2.left;
        rb.velocity = dir * speed;
    }

    void Lanzar()
    {
        Vector2 dir = Random.value > 0.5f ? Vector2.right : Vector2.left;
        rb.velocity = dir * speed;
    }
}
