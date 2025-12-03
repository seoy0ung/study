using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet2 : MonoBehaviour
{
    public GameObject player;
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

        float x = -collision.gameObject.transform.position.x + gameObject.transform.position.x;
        float y = -collision.gameObject.transform.position.y + gameObject.transform.position.y;

        publicx = x;
        publicy = y;



        if (collision.gameObject.CompareTag("Coin"))
        {
            suction();
        }


    }

    public void suction()
    {
        //ª°æ∆µÈ¿Ã±‚
        collided.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        collided.GetComponent<Rigidbody2D>().AddForce(new Vector2(publicx, publicy) * 5, ForceMode2D.Impulse);


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;

    }
}
