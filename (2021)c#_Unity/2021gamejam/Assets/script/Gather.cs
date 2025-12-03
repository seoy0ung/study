using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Gather : MonoBehaviour
{
    GameObject child;
    public GameObject miniplayer;
    public GameObject minibg;
    public GameManager gm;
    private bool end;

    void Start()
    {
    }

    public void Click()
    {
        GameObject btn= EventSystem.current.currentSelectedGameObject;
        gameObject.SetActive(false);
        miniplayer.SetActive(true);
        minibg.SetActive(true);
        miniplayer.GetComponent<Mini>().isgameend = false;

        
    }

  //  IEnumerator Mine()
  //  {
  //      while(true){
  //          yield return new WaitUntil(() => )
  //      }
 //   }
}
