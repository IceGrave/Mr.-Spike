using UnityEngine;

public class MovingSpike : MonoBehaviour {
    private Rigidbody2D rb;
    public float speed = 5f;
    public int pointB = -3;
    public int pointA = -8;
    public string target = "pointB";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the spike back and forth between two targets "pointA" and "pointB"
        if (target == "pointB")
        {
            rb.linearVelocity = new Vector2(speed, 0);
            if (transform.position.x >= pointB)
            {
                target = "pointA";
            }
        }
        else if (target == "pointA")
        {
            rb.linearVelocity = new Vector2(-speed, 0);
            if (transform.position.x <= pointA)
            {
                target = "pointB";
            }
        }
    }
}
