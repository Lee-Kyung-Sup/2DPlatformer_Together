using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    public SpriteRenderer mainSprite;
    EnemyAnimationController enemyAnim;

    private void Awake()
    {
        enemyAnim = GetComponentInParent<EnemyAnimationController>();
        mainSprite = GetComponentInParent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Attack();
    }
    void Attack()
    {
        enemyAnim.EnemyAttack(true);
        //클래스로 체력 공격력설정 능력 설정하고 넣기
        Debug.Log("칼 닿았다.");
    }
    private void FixedUpdate()
    {
        if (mainSprite.flipX == true)
            gameObject.transform.rotation = Quaternion.Euler(0, -180, 0);
        else
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
