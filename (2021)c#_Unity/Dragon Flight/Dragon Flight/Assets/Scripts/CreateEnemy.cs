using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Warning;
    public GameObject Boss;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateDragon());
        StartCoroutine(CreateMeteo());
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0) { return; }
    }
    IEnumerator CreateDragon()
    {
        yield return new WaitForSeconds(3.5f);
        int random1;
        int random2;
        int random3;
        int random4;
        int random5;
        while(true)
        {
            random1 = Random.Range(1, 4);
            random2 = Random.Range(1, 4);
            random3 = Random.Range(1, 4);
            random4 = Random.Range(1, 4);
            random5 = Random.Range(1, 4);
            WE(random1, -4.5f);
            WE(random2, -2.25f);
            WE(random3, 0);
            WE(random4, 2.25f);
            WE(random5, 4.5f);
            if (GameManager.GM.Bosstime >= 50000)
            {
                StartCoroutine(CreateBoss());
                GameManager.GM.Bosstime = 0;
                yield return new WaitWhile(() => GameManager.GM.BossStageStart = true);
            }
            yield return new WaitForSeconds(3f);
        }
    }
    IEnumerator CreateBoss()
    {
        Instantiate(Boss, new Vector3(0, 15, 0), Quaternion.identity);
        GameManager.GM.BossStageStart = true;
        yield break;
    }
    public void WE(int n, float x)
    {
        if (n == 1)
        {
            Instantiate(Enemy1, new Vector3(x, 12f, 0), new Quaternion(0, 0, 0, 0));
        }
        if (n == 2)
        {
            Instantiate(Enemy2, new Vector3(x, 12f, 0), new Quaternion(0, 0, 0, 0));
        }
        if (n == 3)
        {
            Instantiate(Enemy3, new Vector3(x, 12f, 0), new Quaternion(0, 0, 0, 0));
        }
    }
    IEnumerator CreateMeteo()
    {
        yield return new WaitForSeconds(5f);
        while(true)
        {
            float createtime = Random.Range(3f, 10f);
            float createxpos = Random.Range(-4.65f, 4.65f);
            CM(createxpos);
            yield return new WaitForSeconds(createtime);
        }
    }
    public void CM(float xpos)
    {
        Instantiate(Warning, new Vector3(xpos, 8, 0), Quaternion.identity);
    }
}
