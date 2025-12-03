using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage = 20; // 기본 데미지 20, 나중에 업그레이드 하면 배율로 올라가게 하기
    private int PlusDamage;

    // 데미지 증가 함수
    private void Awake()
    {
        PlusDamage = PlayerPrefs.GetInt("WeaponPoint") * 20;
    }
    
    void Start()
    {

        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 20), ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision) // 적한테 닿으면 데미지 넣고 파괴
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")
        {
            collision.GetComponent<Enemy>().Hit(damage);
            Destroy(gameObject);
            
        }
    }   
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 30)
        {
            Destroy(gameObject);
        }
    }
}
