﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EndGame : MonoBehaviour
{
    public GameObject MenuLose;
    public GameObject MenuWin;
    public GameObject OffActive;
    
    void Start()
    {
        OffActive.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombies"))
        {
            Time.timeScale = 0f;
            if (MenuLose != null)
            {
                MenuLose.SetActive(true);
            }
            else Debug.Log("Menu Lose Null");
        }
    }

    public void winGame()
    {
        if(MenuWin != null)
        {
            Time.timeScale = 0f;
            StartCoroutine(InserScore());
            MenuWin.SetActive(true);
        }
        else Debug.Log("Menu Win Null");

    }

    IEnumerator InserScore()
    {
        WWWForm form = new WWWForm();
        form.AddField("token", PlayerPrefs.GetString("token"));
        form.AddField("playerName", GameManager.Instance.namePlayer);
        form.AddField("score", GamePlay.GameTime.ToString());

        UnityWebRequest request = UnityWebRequest.Post("https://fpl.expvn.com/InsertHighscore.php", form);
        yield return request.SendWebRequest();

        if (!request.isDone)
        {
            Debug.Log("ERROR");
        }
        else
        {
            Debug.Log("Finish");
            string get = request.downloadHandler.text;
            if (get.Contains("Done"))
            {
                Debug.Log("Lưu dữ liệu thành công");
            }
            else if (get.Contains("Lỗi"))
            {
                Debug.Log("Không kết nối được sever");
            }
        }
    }

}
