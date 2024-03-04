using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;

    [SerializeField]
    private float Jump;
    [SerializeField]
    Transform pos;
    [SerializeField]
    float checkRadius;
    [SerializeField]
    LayerMask islayer;

    bool IsGround;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Mathf.Abs(rigid.velocity.x) < 0.2f)
        {
            anim.SetBool("IsWalking", false);
        }
        else
        {
            anim.SetBool("IsWalking", true);
        }




        IsGround = Physics2D.OverlapCircle(pos.position, checkRadius, islayer);
        if (Input.GetKeyDown(KeyCode.Space) && IsGround == true)
        { // 점프&&바닥에 닿았을때만
            rigid.velocity = Vector2.up * Jump;
            anim.SetBool("IsJumping", true);
        }
    }

    private void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal"); // 캐릭터 이동
        rigid.velocity = new Vector2(hor * 3, rigid.velocity.y);

        //hor left > -1 , hor right > 1 방향 변경
        if (hor > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (hor < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (rigid.velocity.y < 0) { 
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

            if(rayHit.collider != null)
            {
                if (rayHit.distance < 1f)
                    anim.SetBool("IsJumping", false);
            }
        }

        if (Input.GetKey(KeyCode.X))
        {
            anim.SetTrigger("Crouch");

        }
    }
}
