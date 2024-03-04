using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    public float cooltime;
    private float curtime;


    Rigidbody2D rigid;
    Animator anim;

    public AudioSource mySfx;
    public AudioClip atkSfx;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

   

    // Update is called once per frame
    void Update()
    {
        if (curtime <= 0)
        {
            if (Input.GetKey(KeyCode.Q)&& !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                AtkSound();
                Instantiate(bullet, pos.position, transform.rotation);
                anim.SetTrigger("Attack");

            }
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;
    }

    void AtkSound()
    {
        mySfx.PlayOneShot(atkSfx);
    }
}
