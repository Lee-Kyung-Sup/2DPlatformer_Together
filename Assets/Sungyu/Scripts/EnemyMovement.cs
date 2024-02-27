using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator enemyAnim;
    SpriteRenderer spriteRenderer;
    public int nextMove;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Invoke("Think", 5);
    }

    private void FixedUpdate()
    {
        //Move
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
        //Platform Check
        Vector2 frontVec = new Vector2(rigid.position.x+ nextMove*0.2f,rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1,LayerMask.GetMask("Platform"));
        if(rayHit.collider ==null)
        {
            Turn();            
        }
    }

    void Think()
    {
        //Set Next Active
        nextMove= Random.Range(-1, 2);
        //Recursive
        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);
        //Sprite Animation
        enemyAnim.SetInteger("WalkSpeed", nextMove);
        //Flip Sprite
        if(nextMove != 0)
        spriteRenderer.flipX = nextMove == -1;        
    }

    void Turn()
    {
        nextMove *= -1;
        spriteRenderer.flipX = nextMove == -1;
        CancelInvoke();
        Invoke("Think", 2);
    }
}
