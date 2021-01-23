using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameoverText; //활성화 및 비활성화만 할 것이기에 GameObject타입으로 선언.
    public Text timeText;
    public Text recordText;

    private float surviveTime;
    private bool isGameover;
    
    void Start()
    {
        surviveTime = 0;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover)
         {
            surviveTime += Time.deltaTime;
            timeText.text = "Time : " + (int)surviveTime;
        }

        else {
            if (Input.GetKeyDown(KeyCode.R)) 
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void EndGame() {
        isGameover = true;
        //게임오버 시 텍스트 게임 오브젝트 활성화
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime"); //BestTime으로 저장된 키가 없으면 0반환.

        if (surviveTime > bestTime) 
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        recordText.text = "Best Time: " + (int) bestTime;
    }
}
