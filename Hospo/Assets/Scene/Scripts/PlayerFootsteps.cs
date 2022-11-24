using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource audioSource;
     
    // Start is called before the first frame update
    void Start()
    {
         audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }

        public void Step1()
    {   
        if(Input.GetKey("w")||Input.GetKey("s")||Input.GetKey("d")||Input.GetKey("a"))
       {
            //Debug.Log("Footstep");
            audioSource.Stop();
            AudioClip clip = clips[UnityEngine.Random.Range(0, 2)];
            audioSource.PlayOneShot(clip);

       }   
        

        
    }


     
      

    
   
}
