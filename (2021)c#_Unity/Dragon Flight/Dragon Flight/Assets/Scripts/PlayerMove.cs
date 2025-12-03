using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerMove : MonoBehaviour
{
    public GameObject Bullet;
    public float frame;
    public float PlayerSpeed = 10f;
    public int HP = 3;
    public VariableJoystick joystick;
    public GameObject GameCanvas;
    public GameObject GameOverCanvas;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI FinalScore;
    public TextMeshProUGUI Finalcoin;
    public TextMeshProUGUI Coincount;
    public TextMeshProUGUI GS;
    public GameObject HighScore;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameStart());
    }
    IEnumerator GameStart()
    {
        GS.text = "3";
        yield return new WaitForSeconds(1);
        GS.text = "2";
        yield return new WaitForSeconds(1);
        GS.text = "1";
        yield return new WaitForSeconds(1);
        GS.text = "START!";
        yield return new WaitForSeconds(0.5f);
        GS.enabled = false;

        //Instantiate(Player, new Vector3(0, -8, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0)
        { return; }
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);



        if (pos.x < 0.05f) pos.x = 0.05f;

        if (pos.x > 0.95f) pos.x = 0.95f;

        if (pos.y < 0.05f) pos.y = 0.05f;

        if (pos.y > 0.95f) pos.y = 0.95f;



        transform.position = Camera.main.ViewportToWorldPoint(pos);
        frame += Time.deltaTime;
        if (frame >= 0.1)
        {
            Instantiate(GameManager.GM.Bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
            GameManager.GM.Score += 100;
            GameManager.GM.Bosstime += 100;
            frame = 0;
        }
        if(joystick.GetComponent<Joystick>().Horizontal  >0)
        {
            transform.Translate(new Vector3(1, 0, 0) * PlayerSpeed * Time.deltaTime);
        }
        if (joystick.GetComponent<Joystick>().Horizontal < 0)
        {
            transform.Translate(new Vector3(-1, 0, 0) * PlayerSpeed * Time.deltaTime);
        }
        if (HP <= 0)
        {
            Time.timeScale = 0;
            GameOverCanvas.SetActive(true);
            if(GameManager.GM.HighScore < GameManager.GM.Score)
            {
                GameManager.GM.HighScore = GameManager.GM.Score;
                PlayerPrefs.SetInt("HighScore", GameManager.GM.HighScore);
                HighScore.SetActive(true);
            }
            PlayerPrefs.SetInt("TCoin", GameManager.GM.TotalCoin + GameManager.GM.Coincnt);
            Debug.Log(GameManager.GM.TotalCoin);
        }
        Score.text = GameManager.GM.Score.ToString();
        FinalScore.text = GameManager.GM.Score.ToString();
        Finalcoin.text = GameManager.GM.Coincnt.ToString();
        Coincount.text = GameManager.GM.Coincnt.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
   
        if (collision.gameObject.tag == "Enemy1" || collision.gameObject.tag == "Enemy2" || collision.gameObject.tag == "Enemy3"
            || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "Meteo")
        {
            StartCoroutine(HurtBlink());
        }
    }
    IEnumerator HurtBlink()
    {
        SpriteRenderer Pspr = gameObject.GetComponent<SpriteRenderer>();
        Color Pcolor = Pspr.color;
        int blinkcnt = 0;
        while(blinkcnt <= 3)
        {
            Pcolor.a = 0.5f;
            Pspr.color = Pcolor;
            yield return new WaitForSeconds(0.2f);
            Pcolor.a = 1;
            Pspr.color = Pcolor;
            yield return new WaitForSeconds(0.2f);
            blinkcnt++;
        }
        yield break;
    }
         
    

}
