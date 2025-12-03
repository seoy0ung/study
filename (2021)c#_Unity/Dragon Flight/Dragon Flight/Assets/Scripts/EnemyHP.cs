using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public Image HP;
    float health;
    public float MaxHP;
    public GameObject coin;
    public GameObject Magnet;
    public int coindropcnt;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.tag == "Enemy1") { MaxHP = GameManager.GM.Enemy1HP; coindropcnt = GameManager.GM.Enemy1coin; }
        if (gameObject.tag == "Enemy2") { MaxHP = GameManager.GM.Enemy2HP; coindropcnt = GameManager.GM.Enemy2coin; }
        if (gameObject.tag == "Enemy3") { MaxHP = GameManager.GM.Enemy3HP; coindropcnt = GameManager.GM.Enemy3coin; }
        if (gameObject.tag == "Boss") { MaxHP = GameManager.GM.BossHP; coindropcnt = GameManager.GM.Bosscoin; }
        health = MaxHP;
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -10), ForceMode2D.Impulse);
    }
    public void Hit(float damage)
    {
        health -= damage;
    }
    void Destroyndrop(int cnt)
    {

        float enemyx = transform.position.x;
        float enemyy = transform.position.y;
        int MagnetDrop = Random.Range(1, 11);
        // 파괴되었을 때 적 위치


        // 줘야되는 물리량(상향)

        for (int i = 0; i < cnt; i++)
        {
            float forcex = Random.Range(-2.0f, 2.0f);
            float forcey = Random.Range(3.0f, 5.0f);
            GameObject coins = Instantiate(coin, new Vector2(enemyx, enemyy), Quaternion.identity);


            //coins.GetComponent<Rigidbody2D>().MovePosition(new Vector2 (forcex, forcey));
            coins.GetComponent<Rigidbody2D>().AddForce(new Vector2(forcex, forcey), ForceMode2D.Impulse);
        }
        if(MagnetDrop == 1)
        {
            float forcex = Random.Range(-2.0f, 2.0f);
            float forcey = Random.Range(3.0f, 5.0f);
            GameObject coins = Instantiate(Magnet, new Vector2(enemyx, enemyy), Quaternion.identity);
        }

    }
    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "Boss")
        {
            if(transform.position.y <=6.5)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
        HP.fillAmount = health / MaxHP;
        if(health <= 0)
        {
            Destroyndrop(coindropcnt);
            if (gameObject.tag == "Enemy1") { GameManager.GM.Score += 200; GameManager.GM.Bosstime += 200; }
            if (gameObject.tag == "Enemy2") { GameManager.GM.Score += 400; GameManager.GM.Bosstime += 400; }
            if (gameObject.tag == "Enemy3") { GameManager.GM.Score += 600; GameManager.GM.Bosstime += 600; }
            if (gameObject.tag == "Boss") { GameManager.GM.Score += 1000; GameManager.GM.BossStageStart = false;
                Debug.Log(GameManager.GM.BossStageStart);
            }
            Destroy(this.gameObject);
        }
        if(transform.position.y<-20)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerMove>().HP--;
            Destroy(this.gameObject);
        }
    }
}
