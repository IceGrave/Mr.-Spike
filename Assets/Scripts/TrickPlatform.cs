using UnityEngine;

public class TrickPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rb.linearVelocity = new Vector2(speed, 0);
        }
    }
}
