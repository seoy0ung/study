using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour //Test 하기 위해 잠깐 받아온 스크립트
{
    Rigidbody2D rb;
    Animator anim;
    int jumpcnt = 1;
    int HP = 2;

    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpcnt >= 1)
        {
            rb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

            //anim.SetBool("isjumpended", false);
            //anim.SetTrigger("jump");
            jumpcnt--;

        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Instantiate(Bullet, transform.position + Vector3.one, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mouse"))
        {
            //anim.SetTrigger("ouch");

            Destroy(collision.gameObject);
            HP--;
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            jumpcnt++;
            //anim.SetBool("isjumpended", true);
        }
    }
}
