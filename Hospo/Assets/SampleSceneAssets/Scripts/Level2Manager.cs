using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Level2Manager : MonoBehaviour
{

     public bool playerIsAlive;
     public bool playerBehindCart;
     public bool playerOnLight;
     public levelChangingManager changescene;
     public Volume Vol;
    public float death_time=2f, time_elapsed, complet_percentage;
    [SerializeField] private AnimationCurve deth_vol_curve;
    // Start is called before the first frame update
    void Start()
    {
        playerIsAlive = true;
        playerBehindCart = false;
        playerOnLight = false;
        Vol.weight = 0;
    }
    private void Update()
    {
        
        
            time_elapsed += Time.deltaTime;
            complet_percentage = time_elapsed / death_time;
        
        
    }

    public void setplayerAliveTrue()
    {
        playerIsAlive = true;
    }
    public void setplayerAliveFlase()
    {
        playerIsAlive = false;
    }


    public void setplayerBehindCartTrue()
    {
        playerBehindCart = true;
    }
    public void setplayerBehindCartFlase()
    {
        playerBehindCart = false;
    }


    public void setplayerOnLightTrue()
    {
        playerOnLight = true;
    }
    public void setplayerOnLightFalse()
    {
        playerOnLight = false;
    }
    public void changeScene()
    {
        SceneManager.LoadScene(3);
    }

    public void playerDead()
    {
        
        
            print("i am ded");
        //volume change
        Vol.weight = Mathf.Lerp(0 , 1, deth_vol_curve.Evaluate(complet_percentage));
        // chne the lerp
          Invoke("changeScene", death_time);
          playerIsAlive = false;
  
    }
}
