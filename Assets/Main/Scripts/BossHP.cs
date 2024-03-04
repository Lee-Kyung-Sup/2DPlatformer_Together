using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BossHP : MonoBehaviour
{
    float full = 267f;
    float energy = 0.0f;


    Animator anim;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;

    public string sceneName;
    void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("Bullet"))
        {
            //불릿 태그에 닿았을 때 보스는? 애니메이션 변환(OnDamaged에서)
            OnDamaged(coll.transform.position);

            energy += 5f;
            Destroy(coll.gameObject);
            gameObject.transform.Find("Canvas/HPFront").transform.localScale = new Vector3(energy / full, 0.2666667f, 2.4f);

            if(gameObject.transform.Find("Canvas/HPFront").transform.localScale.x >= 0.267f)
            {
                gameObject.transform.Find("Canvas/HPFront").transform.localScale = new Vector3(0.267f, 0.2666667f, 2.4f);
                //보스 죽는거 생각
                anim.SetTrigger("Die");
                
                Invoke("BossDie", 1f);
            }


        }
    }
    void OnDamaged(Vector2 targetPos) // 보스가 맞았을 때
    {
        //피격 애니메이션
        anim.SetTrigger("Damaged");

        spriteRenderer.color = new Color(0.8396226f, 0.3287202f, 0.3287202f, 1f); // 피격시 색 바뀜

        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1) * 3, ForceMode2D.Impulse);


        Invoke("OffDamaged", 1f);

    }

    void OffDamaged() // 피격 후 레이어 원래대로
    {
      
        spriteRenderer.color = new Color(0.8301887f, 0.7322891f, 0.7322891f, 1f);
    }

    void BossDie()
    {
        gameObject.SetActive(false);
        GameManager.Instance.gameObject.SetActive(false);
        SceneManager.LoadScene(sceneName);
    }
}
