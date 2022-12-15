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

    private int duration = 90;
    private int remainingDuration;
    

    private void Start()
    {

        Being(duration);
    }

    private void Being(int second)
    {
        remainingDuration = second;
        StartCoroutine(UpdateTime());
    }
    public void CheckWinState()
    {
        foreach (GameObject player in players)
        {
           
                if (!player.activeSelf)
                {
                    timeStop = true;
                    Time.timeScale = 0f;
                    music.Stop();
                    playerWon.text = "Draw";
                    Debug.Log("From CheckWinState");
                    gameOver.SetActive(true);
                }
                else if (player.activeSelf)
                {
                    timeStop = true;
                    Debug.Log("From CheckWinState");
                    Time.timeScale = 0f;
                    music.Stop();
                    playerWon.text = player.name + " won";
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
        foreach (GameObject player in players)
        {
            if (remainingDuration <= 0)
            {
                
                    Time.timeScale = 0f;
                    music.Stop();
                    playerWon.text = "Draw";
                    Debug.Log("From UpdateTime");
                    gameOver.SetActive(true);
                    
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
