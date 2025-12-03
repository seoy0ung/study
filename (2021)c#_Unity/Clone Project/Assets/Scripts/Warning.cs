using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 번쩍거리게 하기
// 운석 아래로 떨어지게 하기
public class Warning : MonoBehaviour
{

    float time = 30f;
    float blinktime = 0.5f;
    public GameObject meteo;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Warn());

    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Warn()
    {

        while (true)
        {


            for (int i = 0; i < time; i++)
            {
                float Meteox = player.transform.position.x;
                Vector3 objpos = new Vector3(Meteox, 4f, 1f);

                transform.position = Vector3.Lerp(transform.position, objpos, 5f); // 시험끝나고 부드러워지게 하기..

                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                yield return new WaitForSeconds(blinktime);

                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                yield return new WaitForSeconds(blinktime);
                blinktime *= 0.8f;
               
            }

         Destroy(gameObject);
         Instantiate(meteo, new Vector3(transform.position.x, 6f, transform.position.z), new Quaternion(0, 0, 0, 0));
         break;

        }

    }

}