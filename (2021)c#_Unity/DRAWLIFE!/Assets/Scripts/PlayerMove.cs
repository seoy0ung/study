using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float jump = 5f; // 점프 정도
    Rigidbody2D rb;

    private bool jumping = false; // 현재 점프 중인지 ~ 점프 도중 슬라이드 방지
    //private bool sliding = false;// 현재 슬라이드 중인지 ~ 슬라이드 도중 점프 방지

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(GameManager.GM.Ismale == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = GameManager.GM.MaleImage;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = GameManager.GM.FemaleImage;
        }
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Z)){ // 점프
            if (jumping == false)
            {
                jumping = true;
                rb.AddForce(new Vector3(0, 1, 0) * jump, ForceMode2D.Impulse);
            }
        }

        if(Input.GetKeyDown(KeyCode.X)){ // 슬라이드
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }

        if(Input.GetKeyUp(KeyCode.X)){ // 슬라이드 종료 
            //gameObject.transform.position = new Vector3(-5.5f, -1.66f, 0);
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        
    }

    // 점프 버튼
    public void JumpClick()
    {
        if (jumping == false && !GameManager.GM.isPause)
        {
            jumping = true;
            rb.AddForce(new Vector3(0, 1, 0) * jump, ForceMode2D.Impulse);
        }
    }

    // 점프 끝났을 때
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GROUND") == true) {
            jumping = false;
        }
    }

    // 슬라이드 버튼 ~ 롱클릭으로 작동
    // 버튼 누르면 슬라이드 시작
    public void SlideDown()
    {
        //if (jumping != true)
        //{
        //gameObject.transform.position = new Vector3(-5.5f, -2.16f, 0);
        if(!GameManager.GM.isPause) gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
       // }
    }
    // 버튼 떼면 원상태로
    public void SlideUp()
    {
        //if (jumping != true)
        //{
            //gameObject.transform.position = new Vector3(-5.5f, -1.66f, 0);
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        //}
    }

}
