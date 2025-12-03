using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public GameObject Player;
    public int PlayerHP = 3;
    public float Enemy1HP = 40;
    public float Enemy2HP = 80;
    public float Enemy3HP = 120;
    public int Enemy1coin = 1;
    public int Enemy2coin = 2;
    public int Enemy3coin = 3;
    public int Bosscoin = 100;
    public float BossHP = 400;
    public int Score = 0;
    public int HighScore = 0;
    public int Bosstime = 0;
    public int Coincnt = 0;
    public int TotalCoin = 0;
    public bool BossStageStart = false;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Warning;
    public GameObject Boss;
    public GameObject Coin;
    public GameObject[] Bullets = new GameObject[5];
    public GameObject Bullet;
    IEnumerator CreateDragon()
    {
        yield return new WaitForSeconds(3.5f);
        if (GM.BossStageStart == false)
        {
            StartCoroutine(EnemySpawn());
        }
        else
        {
            StopCoroutine(EnemySpawn());
        }
    }
    public void GotoMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void ReStart()
    {
        SceneManager.LoadScene("IngameScene");
    }
    IEnumerator CreateBoss()
    {
        Instantiate(Boss, new Vector3(0, 15, 0), Quaternion.identity);
        GameManager.GM.BossStageStart = true;
        GameManager.GM.Bosstime = 0;
        yield break;
    }
    IEnumerator EnemySpawn()
    {
        int random1;
        int random2;
        int random3;
        int random4;
        int random5;
        while (true)
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
                Debug.Log(GM.Bosstime);
            }
            yield return new WaitForSeconds(3f);
        }
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
        while (true)
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
    private void Start()
    {
        GM.TotalCoin = PlayerPrefs.GetInt("TCoin");
        GM.HighScore = PlayerPrefs.GetInt("HighScore");
        GM.Bullet = Bullets[PlayerPrefs.GetInt("WeaponPoint")];
        Time.timeScale = 1;
        StartCoroutine(CreateDragon());
        StartCoroutine(CreateMeteo());
        
    }
    private void Awake()
    {
        GM = this;
    }
}
