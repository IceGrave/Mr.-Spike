using UnityEngine;
public class portal : MonoBehaviour
{
    [SerializeField] private Transform destination;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && destination != null)
        {
            collision.transform.position = destination.position;
        }
    }
}
