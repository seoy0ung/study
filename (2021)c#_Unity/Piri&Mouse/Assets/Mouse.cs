using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public int M_HP = 2;
    public float SpeedConstant = 0.01f;
    public float count = 3;

    public GameObject MousePrefab;

    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(Move());
        StartCoroutine(Create());
    }

    public void Die()
    {
        Destroy(MousePrefab);
    }

    private void OnTriggerEnter2D(Collider2D collision) // 총알에 맞으면 피달기, 피 0이면 파괴
    {
        if (collision.gameObject.tag == "Bullet")
        {   
            M_HP -= 1;
            if (M_HP == 0)
            {
                Destroy(MousePrefab);
            }

            // 피격 시 일정시간 정지...
        }
    }

    void Update()
    {
    
    }

    // 쥐 처음에 없다가 나타나게 하기(비활성화/활성화 이용)
    IEnumerator Create()
    {
        while (true)
        {
            Instantiate(MousePrefab, transform.position, new Quaternion(0,0,0,0));
            yield return new WaitUntil(() => M_HP == 0);
            M_HP = 2;
        }
    }

    IEnumerator Move()
    {
        while (true)
        {
            transform.Translate(Vector2.left * SpeedConstant);
            if (transform.position.y < -10) Destroy(MousePrefab);
            yield return null;
        }
    }
}
