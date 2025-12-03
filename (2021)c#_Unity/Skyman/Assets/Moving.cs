using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float SpeedConstant = 0.01f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    IEnumerator Move()
    {
        while (true)
        {
            transform.Translate(Vector2.left * SpeedConstant);
            if (transform.position.x < -10) Destroy(this.gameObject);
            yield return null;
        }
    }
}