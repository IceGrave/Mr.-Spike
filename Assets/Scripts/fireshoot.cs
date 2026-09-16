using System;
using System.Collections;
using UnityEngine;
public class fireshoot : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    private float xPos = 0;
    // The amount of time in seconds that it takes the fireball to spawn and shoot. 
    public float time = 0.45f;
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
    // Spawns the fireball prefab after a certain amount of time has passed. It is spawned at the position of the object this script is attached to.
    IEnumerator spawnFireball()
    {
        yield return new WaitForSeconds(time);
        Instantiate(fireballPrefab, new Vector2(xPos, yPos), Quaternion.identity);
    }
    // Shoots the fireball after a certain amount of time has passed. It is shot to the right at a certain speed which can be adjusted in the editor.
    IEnumerator shootFireball()
    {
        yield return new WaitForSeconds(time);
        rb.linearVelocity = new Vector2(speed, 0);
    }
}
