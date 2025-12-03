using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private int damage = 20;// 기본 데미지 20, 나중에 업그레이드 하면 배율로 올라가게 하기
    private int PlusDamage;
    // Start is called before the first frame update
    private void Awake()
    {
        PlusDamage = PlayerPrefs.GetInt("WeaponPoint") * 20;
    }
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy1" || collision.gameObject.tag == "Enemy2" || collision.gameObject.tag == "Enemy3"
            || collision.gameObject.tag == "Boss")
        {
            collision.GetComponent<EnemyHP>().Hit(damage + PlusDamage);
            Destroy(gameObject);
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
