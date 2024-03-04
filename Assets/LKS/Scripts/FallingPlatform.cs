using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] float fallDelay = 0.5f;
    [SerializeField] float respawnDelay = 2f;

    Rigidbody2D rb;
    PlatformEffector2D platformEffector;
    Vector2 originalPosition;
    bool isFalling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        platformEffector = GetComponent<PlatformEffector2D>();
        originalPosition = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player") && !isFalling)
        {
            Invoke("FallPlatform", fallDelay);
        }
    }

    void FallPlatform()
    {
        rb.isKinematic = false;
        isFalling = true;
        Invoke("RespawnPlatform", respawnDelay);
    }

    void RespawnPlatform()
    {
        transform.position = originalPosition;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        isFalling = false;
    }
}

