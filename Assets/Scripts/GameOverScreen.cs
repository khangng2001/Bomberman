using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("SelectMap");
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
