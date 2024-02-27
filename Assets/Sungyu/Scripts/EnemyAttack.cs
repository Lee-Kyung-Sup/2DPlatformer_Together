using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private BoxCollider2D playerCheck;
    EnemyMovement enemyMovement;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other==playerCheck)
        Debug.Log("검기 날림");
    }
}
