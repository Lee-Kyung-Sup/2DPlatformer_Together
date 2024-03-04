using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text UserMoney;
    public int Money;

    //public int MaxLife = 3;
    //public int currentLife = 3;

    [SerializeField] private GameObject HP1Sprite;
    [SerializeField] private GameObject HP2Sprite;
    [SerializeField] private GameObject HP3Sprite;

    



    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }
    private void Start()
    {
        UserMoney.text = String.Format("{0:#,###}", Money);
    }
}
