using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
// This script is very much similar to fireshoot.cs, but it is adjusted to the boss spike so that it shoots fireballs to the left instead of the right, the rate of fireballs being shot is also slowed down.
public class BossFire : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    private float xPos = 0;
    private float yPos = 0;
    [SerializeField] private GameObject fireballPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xPos = transform.position.x;
        yPos = transform.position.y;
        StartCoroutine(spawnFireball());
        StartCoroutine(shootFireball());
    }
    IEnumerator spawnFireball()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(fireballPrefab, new Vector2(xPos, yPos), Quaternion.identity);
    }
    IEnumerator shootFireball()
    {
        yield return new WaitForSeconds(2f);
        rb.linearVelocity = new Vector2(-speed, 0);
    }
}

