using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class destroydrop : MonoBehaviour
{


    public GameObject coin;
    public GameObject player;
    
    void Destroyndrop(int cnt = 1)
    {

        float enemyx = transform.position.x;
        float enemyy = transform.position.y;
        // 파괴되었을 때 적 위치

        
        // 줘야되는 물리량(상향)

        for (int i = 0; i < cnt; i++)
        {
            float forcex = Random.Range(-2.0f, 2.0f);
            float forcey = Random.Range(3.0f, 5.0f);
            GameObject coins = Instantiate(coin, new Vector2(enemyx, enemyy), Quaternion.identity);


            //coins.GetComponent<Rigidbody2D>().MovePosition(new Vector2 (forcex, forcey));
            coins.GetComponent<Rigidbody2D>().AddForce(new Vector2(forcex, forcey),ForceMode2D.Impulse);
        }

    }

    public void Destroybutton()
    {
        int n = Random.Range(2, 7);
        Destroy(gameObject);

        Destroyndrop(n);
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
