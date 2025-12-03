using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject Coin;
    public GameObject Magnet;
    public Image HP;
    public float MaxHP;
    float currentHP;
    float SpeedConstant = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = MaxHP;
        StartCoroutine(Move());
    }
    public void Hit(float damage)
    {
        currentHP -= damage;
        HP.fillAmount = currentHP / MaxHP;
        if (currentHP <= 0)
        {
            if(gameObject.tag == "Enemy1") { GameManager.GM.Score += 200; GameManager.GM.Bosstime += 200; }
            if (gameObject.tag == "Enemy2") { GameManager.GM.Score += 400; GameManager.GM.Bosstime += 400; }
            if (gameObject.tag == "Enemy3") { GameManager.GM.Score += 600; GameManager.GM.Bosstime += 600; }
            if (gameObject.tag == "Boss")
            {
                GameManager.GM.Score += 3000; GameManager.GM.BossStageStart = false;
            }

            Destroy(this.gameObject);
            Instantiate(Coin, new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
            int MagnetPer = Random.Range(1, 11);
            if(MagnetPer == 1)
            {
                Instantiate(Magnet, new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
            }
            if (transform.position.x < -10)
            {
                Destroy(this.gameObject);
            }
        }
    }
    IEnumerator Move()
    {
        while (true)
        {
            transform.Translate(Vector2.down * SpeedConstant);
            if (transform.position.x < -10) Destroy(this.gameObject);

            if (gameObject.tag == "Boss")
            {
                if (transform.position.y <= 6.5)
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }
            }

            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
