using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    public SpriteRenderer mainSprite;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Ä® ´ê¾Ò´Ù.");   
    }
    private void FixedUpdate()
    {
        if (mainSprite.flipX == true)
            gameObject.transform.rotation = Quaternion.Euler(0, -180, 0);
        else
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
