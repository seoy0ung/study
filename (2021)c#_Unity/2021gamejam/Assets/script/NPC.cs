using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetChild(0).gameObject.activeSelf == true && Input.GetKeyDown(KeyCode.Space))
        {
            canvas.gameObject.SetActive(true);
            if (GameManager.TalkCount < 3)
                GameObject.Find("대사").GetComponent<Text>().text = "뭐라고 말을 걸까요?\n1.요즘 잘지내요 ?\n2.사람들이 어떤 물건을 필요로 할까요 ? ";
            else
                GameObject.Find("대사").GetComponent<Text>().text = "뭐라고 말을 걸까요?\n1.요즘 잘지내요 ?";
            GetComponent<NPC>().enabled = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

    }
    /*private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("범위내");
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.GetChild(0).gameObject.SetActive(false);
            canvas.gameObject.SetActive(true);
            //canvas.transform.GetChild(1).GetComponent<Text>().text = GameManager.data_Dialog[0]["Content"].ToString();
            
        }
    }*/
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

}
