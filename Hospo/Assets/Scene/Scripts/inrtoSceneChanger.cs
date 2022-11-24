using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inrtoSceneChanger : MonoBehaviour
{
    [SerializeField] private float timeToChange;
    [SerializeField] private int sceneNo;
    public void Start()
    {
        Invoke("introchange", timeToChange);
    }
    public void introchange()
    {
        SceneManager.LoadScene(sceneNo);
    }
}
