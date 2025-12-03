using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EditName : MonoBehaviour
{
    public GameObject Name;
    public GameObject Male;
    public void ChangeName() //이름 변경 함수
    {
        PlayerPrefs.SetString("PName", Name.GetComponent<Text>().text);//이름 저장
        Debug.Log("이름 저장 완료");
    }
    public void IsMale() //성별 판단 함수
    {
        PlayerPrefs.SetInt("IsMale", System.Convert.ToInt32(Male.GetComponent<Toggle>().isOn));
        Debug.Log("성별 저장 완료");
        //남자 체크박스가 활성화면 1을, 아니면 0을 저장
    }
    public void EnterGame()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
