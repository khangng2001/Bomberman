using System.Security;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject[] players;

    public GameObject gameOver;
    public TMP_Text playerWon;
    public AudioSource music;
    public TMP_Text timeWatch;
    private bool timeStop = false;

    private int duration = 180;
    private int remainingDuration;
    

    private void Start()
    {
        Time.timeScale = 1f;
        Being(duration);
    }

    private void Being(int second)
    {
        remainingDuration = second;
        StartCoroutine(UpdateTime());
    }
    public void CheckWinState()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (!players[0].activeSelf && !players[1].activeSelf)
            {
                Time.timeScale = 0f;
                music.Stop();
                playerWon.text = "Draw";
                gameOver.SetActive(true);
            }
            else if (!players[0].activeSelf)
            {
                Time.timeScale = 0f;
                music.Stop();
                playerWon.text = players[1].name + " won";
                Debug.Log("From CheckWinState");
                gameOver.SetActive(true);
            }
            else if(!players[1].activeSelf)
            {
                Time.timeScale = 0f;
                music.Stop();
                playerWon.text = players[0].name + " won";
                gameOver.SetActive(true);
            }
            
        }

}
    
    private IEnumerator UpdateTime()
    {
        while (remainingDuration >= 0 && timeStop == false)
        {
            //Debug.Log("Timer: " + remainingDuration / 60 + ": " + remainingDuration % 60);
            //Debug.Log(timeStop);
            timeWatch.text =  "0" + remainingDuration / 60 + " : " + remainingDuration % 60;
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
     if (remainingDuration <= 0){
       for (int i = 0; i < players.Length; i++)
         {
            if (!players[i].activeSelf)
            {
                Time.timeScale = 0f;
                music.Stop();
                playerWon.text = players[i].name + " won";
                Debug.Log("From UpdateTime");
                gameOver.SetActive(true);
                }
                else
                {
                    Time.timeScale = 0f;
                    music.Stop();
                    playerWon.text = "Draw";
                    gameOver.SetActive(true);
                }
         }
                    
     }
 
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SelectMap");
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void BackButton()
    {
        SceneManager.LoadScene("SelectMap");
    }
}
