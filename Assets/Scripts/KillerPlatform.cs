using UnityEngine;

public class KillerPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform player;
    public float speed = 5f;
    public string xY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Depending on the value of xY, the platform will either move left or down when the player is close enough to the platform.
        if (xY == "X")
        {
            if ((Mathf.Abs(transform.position.y - player.position.y) <= 2f) && (Mathf.Abs(transform.position.x + player.position.x) <= 10f))
            {
                rb.linearVelocity = new Vector2(-speed, 0);
            }
        }
        if (xY == "Y")
        {
            if ((Mathf.Abs(transform.position.x - player.position.x) <= 2f) && (Mathf.Abs(transform.position.y + player.position.y) <= 10f))
            {
                rb.linearVelocity = new Vector2(0, -speed);
            }
        }
    }
}
