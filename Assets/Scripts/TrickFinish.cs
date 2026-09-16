using UnityEngine;

public class TrickFinish : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform player;
    public int xpos;
    public int ypos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        // If the player is close enough to the finish line, the finish flag will move to a certain postion.
        if ((Mathf.Abs(transform.position.y - player.position.y) <= 2f) && (Mathf.Abs(transform.position.x - player.position.x) <= 1f))
        {
            transform.position = new Vector2(xpos, ypos);
        }
    }
}
