using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charater : MonoBehaviour
{
    int frame;
    public Sprite[] player_move = new Sprite[16];
    Animator animator;
    Vector2 vel = new Vector2(0, 0);
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("up", true);
        }
        else
            animator.SetBool("up", false);

    }
    void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * Time.deltaTime * 10);
            animator.SetBool("right", true);
        }
        else
            animator.SetBool("right", false);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * Time.deltaTime * 10);
            animator.SetBool("left", true);
        }
        else
            animator.SetBool("left", false);
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * Time.deltaTime * 10);
            animator.SetBool("down", true);
        }
        else
            animator.SetBool("down", false);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * Time.deltaTime * 10);
            animator.SetBool("up", true);
        }
        else
            animator.SetBool("up", false);

    }
}
