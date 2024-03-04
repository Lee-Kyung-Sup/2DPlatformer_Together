using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gold : MonoBehaviour
{
    float currentPositionX;   

    SpriteRenderer spriteRenderer;
    public HealthController health;
    [SerializeField] private GameObject MoneySprite;
    [SerializeField] private GameObject SoldOut1Sprite;
    [SerializeField] private GameObject SoldOut2Sprite;
    [SerializeField] private GameObject SoldOut3Sprite;

    public int Store1Money;
    public int Store2Money;
    public int Store3Money;

    public GameObject NPCUI3;
    public GameObject NPCBeggar;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        health = GameObject.Find("NewFox(key)").GetComponent<HealthController>();
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
        GameManager.Instance.Money = currentValue;
        GameManager.Instance.UserMoney.text = String.Format("{0:#,###}", currentValue);
    }

    public void BuyBtn1()
    {
        int numMoney = GameManager.Instance.Money;
        if (numMoney >= Store1Money)
        {
            currentValue = numMoney - Store1Money;
            GameManager.Instance.Money = currentValue;
            GameManager.Instance.UserMoney.text = String.Format("{0:#,###}", currentValue);
            SoldOut1Sprite.SetActive(true);
        }
        else
        {
            NPCBeggar.SetActive(true);
        }
        
    }
    public void BuyBtn2()
    {
        int numMoney = GameManager.Instance.Money;
        if (numMoney >= Store2Money)
        {
            currentValue = numMoney - Store2Money;
            GameManager.Instance.Money = currentValue;
            GameManager.Instance.UserMoney.text = String.Format("{0:#,###}", currentValue);
            SoldOut2Sprite.SetActive(true);
        }
        else
        {
            NPCBeggar.SetActive(true);
        }
        
    }
    public void BuyBtn3()
    {
        int numMoney = GameManager.Instance.Money;
        if (numMoney >= Store3Money)
        {
            if (health.qtdLife == 3)
            {
                NPCUI3.SetActive(true);
            }
            else
            {
                health.Heal();
                
                currentValue = numMoney - Store3Money;
                GameManager.Instance.Money = currentValue;
                GameManager.Instance.UserMoney.text = String.Format("{0:#,###}", currentValue);
                SoldOut3Sprite.SetActive(true);
            }
        }
        else
        {
            NPCBeggar.SetActive(true);
        }
        
    }
    
}
