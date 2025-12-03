using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinsuction : MonoBehaviour
{
    public GameObject mama;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    float publicx;
    float publicy;
    GameObject collided;
    private void OnTriggerStay2D(Collider2D collision)
    {
        collided = collision.gameObject;

        float x = - collision.gameObject.transform.position.x + gameObject.transform.position.x;
        float y = - collision.gameObject.transform.position.y + gameObject.transform.position.y;

        publicx = x;
        publicy = y;


        
        if (collision.gameObject.CompareTag("Coin"))
        {
            punghyul();
        }


    }

    public void punghyul()
    {
        //빨아들이기


        collided.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        collided.GetComponent<Rigidbody2D>().AddForce(new Vector2(publicx , publicy )*10, ForceMode2D.Impulse);
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = mama.transform.position;

    }
}
