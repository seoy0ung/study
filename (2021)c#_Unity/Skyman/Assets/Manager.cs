using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject CreatePrefab;
    public int count = 5;

    private Vector3 RandomPosition()
    {
        float pX = Random.Range(-7, 10);
        float pY = Random.Range(-3, 4);
        float pZ = 1;

        Vector3 RandomSpawn = new Vector3(pX, pY, pZ);
        return RandomSpawn;
    }
    private Vector3 RandomNew()
    {
        float rX = 11f;
        float rY = Random.Range(-3, 4);
        float rZ = 1;

        Vector3 RandomCreate = new Vector3(rX, rY, rZ);
        return RandomCreate;
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(CreatePrefab, RandomNew(), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }


    }


    // Start is called before the first frame update
    private void Awake()
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(CreatePrefab, RandomPosition(), Quaternion.identity);
        }

    }

    // Update is called once per frame
    private void Start()
    {
        StartCoroutine("Spawn");
    }

   

    private void Update()
    {
        
    }
}
