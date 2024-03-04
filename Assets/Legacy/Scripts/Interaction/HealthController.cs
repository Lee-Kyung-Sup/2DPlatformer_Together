using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HealthController : MonoBehaviour
{
    public float cooldownHit;
    private float rateOfHit;
    public GameObject[] life;
    public int qtdLife;

    

    void Start()
    {
        rateOfHit = Time.time;
        life = GameObject.FindGameObjectsWithTag("Life");
        qtdLife = life.Length;
    }

   

    void OnCollisionEnter2D(Collision2D other)
    {                       //Case of Touch
        if (other.gameObject.tag == "Enemy")
        {
            Hurt();
       
        }
    }
    
    public void Hurt()
    {
        if (rateOfHit < Time.time)
        {
            rateOfHit = Time.time + cooldownHit;
            life[qtdLife - 1].SetActive(false);
            qtdLife -= 1;
            Debug.Log("´ÙÃÆ´ç!");
        }

        if (qtdLife <= 0)
        {
            GameManager.Instance.gameObject.SetActive(false);
            SceneManager.LoadScene("End_3_Scene");
        }
    }
    public void Heal()
    {
        if (qtdLife == 2)
        {
            qtdLife = qtdLife + 1;
            life[2].SetActive(true);
        }
        if (qtdLife == 1)
        {
            qtdLife = qtdLife + 1;
            life[1].SetActive(true);
        }
    }
}