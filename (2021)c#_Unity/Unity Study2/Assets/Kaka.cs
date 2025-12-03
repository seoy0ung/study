using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaka : MonoBehaviour
{
    public Animator Idle;
    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.Getkey(KeyCode.LeftArrow))
        {
            Idle = true;
            gameObject.GetComponent<Animation>().AddForce(-1f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Idle = true;
            gameObject.GetComponent<Animation>().AddForce(1f, 0f);
        }
        if(Input.GetKey(KeyCode.Alt))
        {
            Idle = true;
            gameObject.GetComponent<Animation>().AddForce(new Vector2(0f, 1f), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.z))
        {
            Idle = true;
            gameObject.GetComponent<Animation>();
        }
    }
}
