using UnityEngine;

public class AngrySpike : MonoBehaviour
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
        // Checks if the player is above the spike and close enough to the spike, if the player is then the spike will shoot up vertically at a certain speed which can be adjusted in the editor.
        if ((player.position.y > transform.position.y) && (Mathf.Abs(transform.position.x - player.position.x) <= 1f))
        {
            shoot.Play();
            rb.linearVelocity = new Vector2(0, speed);
        }
    }
}
