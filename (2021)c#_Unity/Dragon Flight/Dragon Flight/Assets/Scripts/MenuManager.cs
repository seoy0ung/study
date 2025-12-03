using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MenuManager : MonoBehaviour
{
    public GameObject Menu1;
    public GameObject Menu2;
    public GameObject Menu3;

    public TextMeshProUGUI MenuCoin;

    public void Start()
    {
        MenuCoin.text = PlayerPrefs.GetInt("TCoin").ToString();
    }
    public void GameStart() // 메뉴에서 게임시작
    {
        SceneManager.LoadScene("IngameScene");
        DontDestroyOnLoad(gameObject);
    }
    public void GameHome() // 메뉴에서 홈으로
    {
        SceneManager.LoadScene("Start");
        DontDestroyOnLoad(gameObject);
    }

    public void GoMenu2() // 메뉴2 열기
    {
        Menu2.SetActive(true);
    }
    public void GoMenu3() // 메뉴3 열기
    {
        Menu2.SetActive(false);
        Menu3.SetActive(true);
        Menu1.SetActive(false);
    }
    public void Back() // 메뉴1로 돌아가기
    {
        Menu3.SetActive(false);
        Menu1.SetActive(true);
    }
}

