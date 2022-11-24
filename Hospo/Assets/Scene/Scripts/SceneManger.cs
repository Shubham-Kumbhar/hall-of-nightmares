using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManger : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene(1);
    }
    /*public void credits()
    {
        SceneManager.LoadScene(0);
    }*/
    public void Quit()
    {
        Application.Quit();
    }

}
