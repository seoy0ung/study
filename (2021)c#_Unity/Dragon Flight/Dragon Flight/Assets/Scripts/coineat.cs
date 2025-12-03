using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coineat : MonoBehaviour
{
    public GameObject suctionarea;
    void Start()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        float x = (2 * collision.gameObject.transform.position.x + gameObject.transform.position.x) / 3;
        float y = (2 * collision.gameObject.transform.position.y + gameObject.transform.position.y) / 3;


        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Magnet"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(magnettime());
        }

        IEnumerator magnettime()
        {
            suctionarea.GetComponent<CircleCollider2D>().radius = 10;

            yield return new WaitForSeconds(5f);

            suctionarea.GetComponent<CircleCollider2D>().radius = 1.693362f;
        }


    }


    void Update()
    {
        
    }
}
