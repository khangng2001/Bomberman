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
    private bool winGame = false;

    private int duration = 180;
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
        /*int aliveCount = 0;*/
        
        foreach (GameObject player in players)
        {
            if (player.activeSelf)
            {
                music.Stop();
                winGame = true;
                playerWon.text = player.name + " won";
                gameOver.SetActive(true);
                
            }
        }
    }
    
    private IEnumerator UpdateTime()
    {
        while (remainingDuration >= 0 && winGame == false)
        {
            Debug.Log("Timer: " + remainingDuration / 60 + ": " + remainingDuration % 60);
            timeWatch.text =   remainingDuration / 60 + " : " + remainingDuration % 60;
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        yield return null;
        if (remainingDuration <= 0)
        {
            Time.timeScale = 0f;
            music.Stop();
            gameOver.SetActive(true);
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
