using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chageSpeedCollider : MonoBehaviour
{
    public GameObject trollyspeed;

 
    public void OnTriggerEnter(Collider other)
    {

            trollyspeed.GetComponent<trolluMove>().chageNextSpeed();
            trollyspeed.GetComponent<trolluMove>().changeSpeed();
        
    }
}
