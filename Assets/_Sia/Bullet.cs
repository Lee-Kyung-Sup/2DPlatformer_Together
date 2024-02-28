using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    public float distance;
    public LayerMask isLayer;
    void Start()
    {
        Invoke("DestroyBullet", 2);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer); // (시작점, 방향, 길이, 레이어선택)
        if(ray.collider != null)
        {
            if (ray.collider.tag == "Enemy") {
                Debug.Log("명중");
            }
            DestroyBullet();
        }

        if(transform.rotation.y == 0) {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
