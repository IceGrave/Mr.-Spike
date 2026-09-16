using UnityEngine;

public class HorizontalAngrySpike : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform player;
    public float speed = 5f;
    public AudioSource shoot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.y - player.position.y) <= 7f && (Mathf.Abs(transform.position.x - player.position.x) <= 1f))
        {
            if (transform.position.x > player.position.x)
            {
                shootLeft();
            }
            else
            {
                shootRight();
            }
        }
    }
    private void shootLeft()
    {
        shoot.Play();
        rb.linearVelocity = new Vector2(-speed, 0);
    }
    private void shootRight()
    {
        shoot.Play();
        rb.linearVelocity = new Vector2(speed, 0);
    }
}
