using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camrotate : MonoBehaviour
{
    [SerializeField] Vector3 vector_cam;
    [SerializeField] float rotation_Angle = 0;
    [SerializeField] float x = 0f;
    [SerializeField] float z = 0f;

    void Update()
    {
        vector_cam = new Vector3(x, rotation_Angle * Mathf.Sin(Time.realtimeSinceStartup), z);
        transform.rotation = Quaternion.Euler(vector_cam);
    }
}

