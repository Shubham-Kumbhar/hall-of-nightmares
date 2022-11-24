using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollyCollider : MonoBehaviour
{
    public GameObject Manager;
    


    public void Start()
    {
        

    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("hello world");
            Manager.GetComponent<Level2Manager>().setplayerBehindCartTrue();

        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            print("exit world");
            Manager.GetComponent<Level2Manager>().setplayerBehindCartFlase();
        }
        
    }
}
