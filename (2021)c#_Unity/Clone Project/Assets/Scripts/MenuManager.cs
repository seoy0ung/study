using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject Menu1;
    public GameObject Menu2;
    public GameObject Menu3;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameStart() // 메뉴에서 게임시작
    {
        SceneManager.LoadScene("InGame");
        DontDestroyOnLoad(gameObject);
    }
    public void GameHome() // 메뉴에서 홈으로
    {
        SceneManager.LoadScene("Start");
        DontDestroyOnLoad(gameObject);
    }

    public void GoMenu2()
    {
        Menu2.SetActive(true);
    }
    public void GoMenu3()
    {
        Menu3.SetActive(true);
        Menu1.SetActive(false);
    }
    public void Back()
    {
        Menu2.SetActive(false);
        Menu3.SetActive(false);
        Menu1.SetActive(true);
    }
}

