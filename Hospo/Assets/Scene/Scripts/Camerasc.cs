using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerasc : MonoBehaviour
{
    public GameObject player;
 // Use this for initialization
 void Start () {
     
 }
 
 // Update is called once per frame
 void LateUpdate () {
     Vector3 offset = transform.position - player.transform.position;
     bool changeInX = false;
     bool changeInY = false;
     Vector3 newCameraPosition = transform.position;
     if (offset.x > 2)
     {
         changeInX = true;
         newCameraPosition.x = (player.transform.position.x + offset.x) - (offset.x - 2);
     }
     else if (offset.x < -2)
     {
         changeInX = true;
         newCameraPosition.x = (player.transform.position.x + offset.x) - (offset.x + 2);
     }
     if (offset.y > 1.5f)
     {
         changeInY = true;
         newCameraPosition.y = (player.transform.position.y + offset.y) - (offset.y - 1.5f);
     }
     else if (offset.y < -1.5f)
     {
         changeInY = true;
         newCameraPosition.y = (player.transform.position.y + offset.y) - (offset.y + 1.5f);
     }
     if (!changeInX)
     {
         newCameraPosition.x = transform.position.x;
     }
     if (!changeInY)
     {
         newCameraPosition.y = transform.position.y;
     }
     transform.position = newCameraPosition;
 }
}
