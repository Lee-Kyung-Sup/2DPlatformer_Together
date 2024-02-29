using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    [SerializeField] float disappearTime = 0.7f, returnTime = 1f;
    Rigidbody2D rb;
    Vector2 startPos;
    bool isBack;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isBack)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos, 20 * Time.deltaTime);
        }
        if(transform.position.y == startPos.y)
        {
            isBack = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("Player") && !isBack)
        {
            Invoke("DisappearPlatform", disappearTime);
        }
    }

    void DisappearPlatform()
    {
        rb.isKinematic = false;
        Invoke("ReturnPlatform", returnTime);
    }

    void ReturnPlatform()
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        isBack = true;
    }
}
