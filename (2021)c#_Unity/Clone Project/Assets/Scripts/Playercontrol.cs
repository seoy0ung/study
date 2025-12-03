using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Playercontrol : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject MagnetE;
    public VariableJoystick Joy;
    public int PlayerHP;
    float C_HP;
    public float SpeedConstant = 10f;
    public float frame;
    public GameObject GameCanvas;
    public GameObject GameOverCanvas;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI FinalScore;
    public TextMeshProUGUI Finalcoin;
    public TextMeshProUGUI Coincount;
    public GameObject HighScore;


    // Start is called before the first frame update
    void Start()
    {
        C_HP = PlayerHP;
        StartCoroutine(bullet());
        StartCoroutine(Distance());
    }

    IEnumerator bullet() // 두두두두 하고 총알 나옴
    {
        while (true)
        {
            Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
            yield return new WaitForSeconds(0.1f);
        }

    }

    IEnumerator Distance()
    {
        frame += Time.deltaTime;
        if (frame >= 0.1)
        {
            Instantiate(GameManager.GM.Bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
            GameManager.GM.Score += 100;
            GameManager.GM.Bosstime += 100;
            frame = 0;
        }
        yield return null;
    }

    // 충돌 효과
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Magnet"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(Magnettime());
            Debug.Log("자석!");
        }

        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")
        {
            C_HP -= 1;
            Destroy(collision.gameObject);
            StartCoroutine(HurtBlink());
        }

        if (collision.gameObject.tag == "Meteo")
        {
            C_HP -= 2;
            Destroy(collision.gameObject);
            StartCoroutine(HurtBlink());
        }



    }

    IEnumerator Magnettime() // 자석 효과 범위 증가 코루틴
    {
       MagnetE.GetComponent<CircleCollider2D>().radius = 5;
       yield return new WaitForSeconds(3);
       MagnetE.GetComponent<CircleCollider2D>().radius = 0.7f;
    }
    IEnumerator HurtBlink()
    {
        SpriteRenderer Blink = gameObject.GetComponent<SpriteRenderer>();
        Color B_color = Blink.color;
        int blinkcnt = 0;
        while (blinkcnt <= 3)
        {
            B_color.a = 0.5f;
            Blink.color = B_color;
            yield return new WaitForSeconds(0.2f);
            B_color.a = 1;
            Blink.color = B_color;
            yield return new WaitForSeconds(0.2f);
            blinkcnt++;
        }
        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        // 조이스틱으로 움직이기
        if (Joy.GetComponent<Joystick>().Horizontal > 0)
        {
            transform.Translate(Vector2.right * SpeedConstant * Time.deltaTime);
        }

        if (Joy.GetComponent<Joystick>().Horizontal < 0)
        {
            transform.Translate(Vector2.left * SpeedConstant * Time.deltaTime);
        }

        if (Time.timeScale == 0)
        { return; }

        // 피 0이면 게임 오버, 점수출력
        if (C_HP <= 0)
        {
            Time.timeScale = 0;
            GameOverCanvas.SetActive(true);
            if (GameManager.GM.HighScore < GameManager.GM.Score)
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






        // 벽 밖으로 못나가게
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);



        if (pos.x < 0.05f) pos.x = 0.05f;

        if (pos.x > 0.95f) pos.x = 0.95f;

        if (pos.y < 0.05f) pos.y = 0.05f;

        if (pos.y > 0.95f) pos.y = 0.95f;



        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}