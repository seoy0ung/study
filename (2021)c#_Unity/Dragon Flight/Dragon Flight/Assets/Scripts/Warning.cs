using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    public GameObject Meteo;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Blink());
    }
    public IEnumerator Blink()
    {
        float time = 0.5f;
        int cnt = 0;
        SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer>();
        Color col = spr.color;
        while(true)
        {
            yield return new WaitForSeconds(time);
            col.a = 0;
            spr.color = col;
            cnt++;
            time = time * 0.8f;
            yield return new WaitForSeconds(time);
            col.a = 1;
            spr.color = col;
            if(cnt == 10)
            {
                Destroy(gameObject);
                Destroy(transform.FindChild("WarningLine").gameObject);
                Instantiate(Meteo, new Vector3(transform.position.x, 12, transform.position.z), new Quaternion(0, 0, 0, 0));
            }
        }
    }

    
}
