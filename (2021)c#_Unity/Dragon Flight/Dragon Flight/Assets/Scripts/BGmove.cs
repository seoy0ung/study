using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGmove : MonoBehaviour
{
    public float speed = 100f;
    // Start is called before the first frame update
    private void Start()
    {
        
    }
    private void Update()
    {
        gameObject.transform.Translate(new Vector3(0, -1, 0) * speed * Time.deltaTime);
        if(gameObject.transform.position.y < -20)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
  
   
}
