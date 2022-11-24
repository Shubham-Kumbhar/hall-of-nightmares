using UnityEngine;
using System.Collections;


public class trolluMove : MonoBehaviour
{
    public int direction;
    public bool switch_check;
    [SerializeField] private float speed, maxDist = 1f, minDist = 0f;
    public float  nextSpeed;
    [SerializeField] private Vector3 move,saveedpose;
    public float test;

    void Start()
    {
        direction = 1;
        switch_check = true;
        saveedpose= this.transform.position; // was giving offset because of the positoin of its parent //this is fix
        
    }

    // Update is called once per frame
    void Update()
    {
        if (switch_check)
        {

            move = new Vector3(speed * direction, 0f, 0f);
            transform.Translate(move * Time.deltaTime);
           // this.transform.position = transform.position + (move * Time.deltaTime);
        }
        if (this.transform.position.x > saveedpose.x + maxDist)
        {
            direction = -1;
        } else if (this.transform.position.x < saveedpose.x + minDist)
        {
            direction = 1;
        }




    }

    IEnumerator ChangeSpeed(float v_start, float v_end, float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            
            speed = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        speed = v_end;
    }

    public void changeSpeed()
    {
        StartCoroutine(ChangeSpeed(speed, nextSpeed, 1f));
    }

    public void chageNextSpeed()
    {
        nextSpeed = Random.Range(2, 7);
    }


}
