using UnityEngine;

public class InvisiblePlatform : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the player is on the platform, if the player is on the platform, an animation will play and the platform will become visible.
        if (Mathf.Abs(transform.position.y - player.position.y) <= 1f && (Mathf.Abs(transform.position.x - player.position.x) <= 1f))
        {
            animator.SetBool("playerOn", true);
        }
        else
        {
            animator.SetBool("playerOn", false);
        }
    }
}
