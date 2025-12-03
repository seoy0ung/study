using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour
{
    public GameObject CollectionUI;

    public void GameStart(){ // 게임 시작 버튼 
        SceneManager.LoadScene("NameScene");
    }

    public void OpenCollection(){ // 도감 열기
        CollectionUI.SetActive(true);
    }

    public void CloseCollection(){ // 도감 닫기
        CollectionUI.SetActive(false);
    }

    public void MainBtn(){ // 메인으로 버튼
        SceneManager.LoadScene("MainScene");
    }

    public void QuizBtn(){
        if(EventSystem.current.currentSelectedGameObject.transform.Find("Text").gameObject.GetComponent<Text>().text == GameManager.GM.njob)
            GameManager.GM.CorF = 1; // 정답
        else
            GameManager.GM.CorF = 2;
    }

}
