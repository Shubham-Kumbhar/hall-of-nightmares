using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorContoler : MonoBehaviour
{
    public GameObject flickers;
    public GameObject RedCircle;
    public GameObject GreenCircle;
    public float Delayetime = 8f;
    public Animator animator;
    public bool enteredSwitch;
    public bool pressedSwitch;



    public AudioSource DoorSound;
    public AudioSource DoorCloseSound;
    public AudioSource TickingSound;




    public void Start()
    {
        animator = GetComponent<Animator>();
        enteredSwitch = false;
        flickers.SetActive(false);
        GreenCircle.SetActive(false);
        RedCircle.SetActive(true);
        pressedSwitch = false;
    }

    public void Update()
    {
        if( Input.GetKeyDown("e") && enteredSwitch && !pressedSwitch)
        {
            animator.SetBool("character_nearby", true);
            flickers.SetActive(true);
            GreenCircle.SetActive(true);
            RedCircle.SetActive(false);
            pressedSwitch = true;
            DoorSound.Play();
            Invoke("timeduration", Delayetime);
            Invoke("startTicking", 2.0f);
            



        }
    }

    public void OnTriggerEnter(Collider other)
    {   
        if (other.name == "Player")
        {
            Debug.Log("entered");
            enteredSwitch = true;
 
        }
        
        
    }

    public void OnTriggerExit(Collider other)
    {
         if (other.name == "Player")
        {
            Debug.Log("exit");
            enteredSwitch = false;
        }
        
    }


    void timeduration()
    {   
        
        animator.SetBool("character_nearby", false);
        DoorCloseSound.Play();
        flickers.SetActive(false);
        GreenCircle.SetActive(false);
        RedCircle.SetActive(true);
        pressedSwitch = false;
        Invoke("stopTicking", 1.5f);
        
    }

    void startTicking()
    {
        TickingSound.Play();
    }
    void stopTicking()
    {
        TickingSound.Stop();
    }
}
