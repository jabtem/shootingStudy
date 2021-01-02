using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager ginstance;
    int score = 0;
    public Text scoreTxt;
    public GameObject readyTxt;
    public GameObject gameover;
    public GameObject player;
    public bool PlayerAlive = true;
    public Vector3 startPos;
    // Start is called before the first frame update
    void Awake()
    {
        if(ginstance == null)
        {
            ginstance = this;
        }
        //게임 시작시의 플레이어 위치 받아옴
        startPos = player.transform.position; 
    }
    void Start()
    {
        Invoke("StartGame", 3.0f);
        StartCoroutine(showReady());
    }
    void StartGame()
    {
        PlayerCtrl.canShot = true;
        SpawnManager.isSpawn = true;
      
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void ShowGameOver()
    {
        gameover.SetActive(true);
    }
    public void KillPlayer()
    {
        PlayerAlive = false;
        SpawnManager.isSpawn = false;
        ShowGameOver();
    }
    public void AddScore(int _score)
    {
        score += _score;
        //Debug.Log(score);
        scoreTxt.text = "Score : " + score;
    }
    IEnumerator showReady()
    {
        int count = 0;
        bool active;
        while(count < 5)
        {
            //if(readyTxt.activeSelf == true)
            //{
            //    readyTxt.SetActive(false);
            //}
            //else
            //    readyTxt.SetActive(true);

            active = (readyTxt.activeSelf == true) ? false : true;
            readyTxt.SetActive(active);
            yield return new WaitForSeconds(0.5f);
            count++;
        }

    }

    void RestartReady()
    {
        gameover.SetActive(false);
        player.SetActive(true);
        readyTxt.SetActive(true);
        StartCoroutine(showReady());
    }
    public void InitGame()
    {
        ObjectManager.oinstance.Clearbullets();
        ObjectManager.oinstance.Clearenemys();
        score = 0;
        scoreTxt.text = string.Empty;
        PlayerAlive = true;
        player.transform.position = startPos;
        RestartReady();
        Invoke("StartGame", 3.0f);
    }
}
