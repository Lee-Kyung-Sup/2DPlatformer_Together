using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class NPC_Movement1 : MonoBehaviour
{
    float rightMax = 87.0f;
    float leftMax = 83.0f;
    float currentPositionX;
    float direction = 2.0f;

    Animator anim;
    SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject Penguin;
    [SerializeField] private GameObject Gold;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        currentPositionX = transform.position.x;
    }

    private void Update()
    {
        currentPositionX += Time.deltaTime * direction;

        if(currentPositionX >= rightMax) 
        {
            direction *= -1;
            currentPositionX = rightMax;
            spriteRenderer.flipX = true;
        }
        else if(currentPositionX <= leftMax)
        {
            direction *= -1;
            currentPositionX = leftMax;
            spriteRenderer.flipX = false;
        }
        anim.SetBool("IsWalking", true);

        transform.position = new Vector3(currentPositionX, -2.31f, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            direction = 0;
            foreach (SpriteRenderer renderer in transform.GetComponentsInChildren<SpriteRenderer>())
            {
                Color color = renderer.color;
                color.a = 0.3f;
                renderer.color = color;
            }

            foreach (Behaviour component in transform.GetComponentsInChildren<Behaviour>())
            {
                component.enabled = false;
            }
            Invoke("PenguinBye", 1f);
            //Destroy(this.gameObject, 2f);
            MakeGold();
        }
    }
    public void PenguinBye()
    {
        Penguin.SetActive(false);
    }
    void MakeGold()
    {
        Gold.SetActive(true);
    }
}
