using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenSwitcher : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SelectMap");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}