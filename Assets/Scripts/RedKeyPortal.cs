using UnityEngine;

public class RedKeyPortal : MonoBehaviour
{
    [SerializeField] private Transform destination;
    public Player player;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && destination != null)
        {
            if (player.redkeyObtained)
            {
                collision.transform.position = destination.position;
            }
        }
    }
}
