using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapsScreen : MonoBehaviour
{
    public void backToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void moveToMapOne()
    {
        SceneManager.LoadScene("Map01");
    }
    public void moveToMapTwo()
    {
        SceneManager.LoadScene("Map02");
    }
    public void moveToMapThree()
    {
        SceneManager.LoadScene("Map03");
    }
    public void moveToMapFour()
    {
        SceneManager.LoadScene("Map04");
    }
}