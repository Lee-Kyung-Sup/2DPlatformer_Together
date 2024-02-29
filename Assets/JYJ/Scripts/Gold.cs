using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    float currentPositionX;   

    SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject MoneySprite;
    
    

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
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
            GainMoney();
            Invoke("MoneyBye", 1f);
            //Destroy(this.gameObject, 2f);
        }
    }
    public void MoneyBye()
    {
        MoneySprite.SetActive(false);
    }

    private int currentValue;
    public void GainMoney()
    {
        int numMoney = GameManager.Instance.Money;

        currentValue = numMoney + UnityEngine.Random.Range(22222, 44444);
        GameManager.Instance.UserMoney.text = String.Format("{0:#,###}", currentValue);
    }

}
