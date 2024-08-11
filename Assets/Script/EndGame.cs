using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            MenuWin.SetActive(true);
        }
        else Debug.Log("Menu Win Null");

    }
}
