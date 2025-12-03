using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    public int HP = 3;
    public int frame = 0;
    public int jumpcount = 0;
    public GameObject = Goblin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetkeyDown(KeyCode.Space) && jumpcount > 0)
        {
            jumpcount -= 1;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 10f), ForceMode2D.impulse);
        }

        frame++;
        if(frame % 40 == 0)
        {
            Instantiate(Goblin, new Vector3(4 + Random.Range(0f, 1f), 0, 0), Quaternium.identity);
        }
    }
}

private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Goblin"))
    {
        Destroy(collision.gameObject);
        HP--;
        jumpcount += 2;

        if(HP == 0)
        {
            Debug.Log("³ª Á×¾ú¾î");
            Destroy(gameObject);
        }
    }
    // else if (co)
}