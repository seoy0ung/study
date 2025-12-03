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
    public int PlayerHP = 2;
    public float Enemy1HP = 40;
    public float Enemy2HP = 80;
    public float Enemy3HP = 120;
    public int Enemy1coin = 1;
    public int Enemy2coin = 2;
    public int Enemy3coin = 3;
    public int Bosscoin = 100;
    public float BossHP = 2000;
    public int Score = 0;
    public int HighScore = 0;
    public int Bosstime = 0;
    public int Coincnt = 0;
    public int TotalCoin = 0;
    public bool BossStageStart = false;
    public float speed = 10f;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Boss;
    public GameObject Warning;
    public GameObject Coin;
    public GameObject[] Bullets = new GameObject[5];
    public GameObject Bullet;

    private void Awake()
    {
        GM = this;
    }

    // Scene
    public void Replay() // 게임에서 게임으로
    {
        SceneManager.LoadScene("InGame");
    }
    public void GoMenu() // 게임에서 메뉴로
    {
        SceneManager.LoadScene("Menu");
        DontDestroyOnLoad(gameObject);
    }

    // 적 생성
    IEnumerator CreateEnemy()
    {
        yield return new WaitForSeconds(3.5f);
        if (GM.BossStageStart == false)
        {
            StartCoroutine(CreateDragon());
        }
        else
        {
            StopCoroutine(CreateDragon());
        }
    }
    IEnumerator CreateDragon()
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
            WE(random1, -2.2f);
            WE(random2, -1.1f);
            WE(random3, 0);
            WE(random4, 1.1f);
            WE(random5, 2.2f);
            if (GameManager.GM.Bosstime >= 20000)
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
            Instantiate(Enemy1, new Vector3(x, 7.7f, 0), new Quaternion(0, 0, 0, 0));
        }
        if (n == 2)
        {
            Instantiate(Enemy2, new Vector3(x, 7.7f, 0), new Quaternion(0, 0, 0, 0));
        }
        if (n == 3)
        {
            Instantiate(Enemy3, new Vector3(x, 7.7f, 0), new Quaternion(0, 0, 0, 0));
        }
    }

    IEnumerator CreateBoss()
    {
        Instantiate(Boss, new Vector3(0, 15, 0), Quaternion.identity);
        GameManager.GM.BossStageStart = true;
        GameManager.GM.Bosstime = 0;
        yield break;
    }

    // 운석 생성
    IEnumerator CreateMeteo()
    {
        
        while (true)
        {
            GameObject.Find("Warning");
            yield return new WaitForSeconds(5f);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        GM.TotalCoin = PlayerPrefs.GetInt("TCoin");
        GM.HighScore = PlayerPrefs.GetInt("HighScore");
        GM.Bullet = Bullets[PlayerPrefs.GetInt("WeaponPoint")];

        Time.timeScale = 1;
        StartCoroutine(CreateEnemy());
        StartCoroutine(CreateMeteo());


    }

    // Update is called once per frame
    void Update()
    {
    }

}
