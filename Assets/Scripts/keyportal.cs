using UnityEngine;

public class keyportal : MonoBehaviour
{
    [SerializeField] private Transform destination;
    public Player player;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && destination != null)
        {
            if (player.keyObtained)
            {
                collision.transform.position = destination.position;
            }
        }
    }
}
