using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camCollider : MonoBehaviour
{
    public GameObject Manager;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Manager.GetComponent<Level2Manager>().setplayerOnLightTrue();


        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Manager.GetComponent<Level2Manager>().setplayerOnLightFalse();
        }

    }
}
