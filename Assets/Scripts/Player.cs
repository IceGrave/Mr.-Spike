using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Controls how fast the player runs and how high the player jumps. These values can be changed in the editor. 
    public float speed = 5f;
    public float jumpForce = 6f;
    [SerializeField] private Animator animator;
    private Rigidbody2D rb;
    public LogicScript logic;
    public bool playerIsAlive = true;
    private SpriteRenderer sr;
    // Determines the size of the box used to detect if the player is on the ground or not. This can be changed in the editor.
    public Vector2 boxSize;
    // Determines the distance the box is casted down to detect if the player is on the ground or not. This can be changed in the editor.
    public float castDistance;
    // Determines which layers are considered the ground for the player. 
    public LayerMask groundLayer;
    // Stores some of the sound effects used in the game.
    public AudioSource jump;
    public AudioSource move;
    public AudioSource moveGrass;
    public AudioSource moveBricks;
    public AudioSource key;
    public AudioSource celebrate;
    // Detects whether the player is able to move yet or not. This is used to prevent the player from moving when dialogue is being shown. 
    static bool canMove = true;
    // Checks whether certain keys have been obtained by the player.
    public bool keyObtained = false;
    public bool greenkeyObtained = false;
    public bool redkeyObtained = false;
    public bool orangekeyObtained = false;
    public bool pinkkeyObtained = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Checks which level the player is currently on and plays the appropriate movement sound effect based on the level.
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 13)
        {
            celebrate.Play();
        }
        if (scene.buildIndex > 10)
        {
            move = moveBricks;
        }
        else
        {
            move = moveGrass;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!canMove)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }
        float input = Input.GetAxisRaw("Horizontal");
        // Detects whether the player is moving horizontally, and if the player is a running animation is played. If not, an idle animation is played.
        if (input != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        if (playerIsAlive == false)
        {
            return;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // First checks if the player is grounded, and if so, the running sound effect is played if it is not already being played. And if not, the sound effect will stop.
            if (isGrounded())
            {
                if (!move.isPlaying)
                {
                    move.Play();
                }
            }
            else
            {
                move.Stop();
            }
            // Since the player is moving left, the player's speed is negative and the sprite will be flipped to face left.
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
            sr.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // First checks if the player is grounded, and if so, the running sound effect is played if it is not already being played. And if not, the sound effect will stop.
            if (isGrounded())
            {
                if (!move.isPlaying)
                {
                    move.Play();
                }
            }
            else
            {
                move.Stop();
            }
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
            sr.flipX = false;
        }
        else
        {
            move.Stop();
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
        if (Input.GetKeyDown(KeyCode.W) && isGrounded() || Input.GetKeyDown(KeyCode.UpArrow) && isGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jump.Play();
        }
        // If player is off the screen, it is considered game over and the player dies.
        if (rb.position.y < -10)
        {
            playerIsAlive = false;
            animator.SetBool("isDead", true);
            logic.gameOver();
            return;
        }
    }
    // Disables or Enables the player's movement based on if there is dialogue to be shown. If there is dialogue being shown the player is not able to move at all until the dialogue is finished.
    public void DisableMovement()
    {
        canMove = false;
    }

    public void EnableMovement()
    {
        canMove = true;
    }
    void OnTriggerEnter2D(Collider2D collison)
    {
        if (!playerIsAlive)
        {
            return;
        }
        // When the player collides with a spike, the player dies and the death aniumation is played. 
        if (collison.CompareTag("Spike"))
        {
            playerIsAlive = false;
            animator.SetBool("isDead", true);
            rb.linearVelocity = new Vector2(0, 0);
            logic.gameOver();
            return;
        }
        // Player goes to the next level when they touch the finish flag.
        if (collison.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            return;
        }
        // Checks whether the player has collected a certain key, and if so, the key is destroyed the collect sound effect is played. The player uses the collected key to go through the color appropriate portal.
        if (collison.CompareTag("Key"))
        {
            keyObtained = true;
            Destroy(collison.gameObject);
            key.Play();
            return;
        }
        if (collison.CompareTag("Green Key"))
        {
            greenkeyObtained = true;
            Destroy(collison.gameObject);
            key.Play();
            return;
        }
        if (collison.CompareTag("Red Key"))
        {
            redkeyObtained = true;
            Destroy(collison.gameObject);
            key.Play();
            return;
        }
        if (collison.CompareTag("Orange Key"))
        {
            orangekeyObtained = true;
            Destroy(collison.gameObject);
            key.Play();
            return;
        }
        if (collison.CompareTag("Pink Key"))
        {
            pinkkeyObtained = true;
            Destroy(collison.gameObject);
            key.Play();
            return;
        }
    }

    public bool isGrounded()
    {
        // Casts a box to check if the player is on the ground or not. If the box collides with the ground, the player is grounded, and if not, the player is not grounded.
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void OnDrawGizmos()
    {
        // Draws a box to check if the player is grounded.
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);

    }
}
