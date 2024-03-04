using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossHP : MonoBehaviour
{
    float full = 267f;
    float energy = 0.0f;
  

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("Bullet"))
        {
            energy += 5f;
            Destroy(coll.gameObject);
            gameObject.transform.Find("Canvas/HPFront").transform.localScale = new Vector3(energy / full, 0.2666667f, 2.4f);

            if(gameObject.transform.Find("Canvas/HPFront").transform.localScale.x >= 0.267f)
            {
                gameObject.transform.Find("Canvas/HPFront").transform.localScale = new Vector3(0.267f, 0.2666667f, 2.4f);
            }
            
            
        }
    }
}
