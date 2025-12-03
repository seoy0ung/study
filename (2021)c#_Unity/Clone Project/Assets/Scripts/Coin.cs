using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // 나중에 item 으로 바꿔서 (랜덤아이템, 랜덤갯수) 생성으로 만들기
    //public GameObject MagnetEffect;
    //public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.one, ForceMode2D.Impulse);
    }

    

    
// Update is called once per frame
void Update()
    {
        
    }
}
