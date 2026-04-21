using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource audioSource;

    public float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        GameController.Tick(Time.deltaTime);
    }

    void FixedUpdate()
    {
        if (GameController.gameOver)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coletavel"))
        {
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }

            GameController.Collect();
            Destroy(other.gameObject);
        }
    }
}