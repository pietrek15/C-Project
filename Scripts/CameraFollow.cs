﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform target;            
    public float smoothing = 5f;       

    Vector3 offset;                     


    public void Start()
    {  
        target = GameObject.FindGameObjectWithTag("Player").transform; 
        offset = transform.position + target.position;
    }


    void FixedUpdate()
    {
        if (target == null)
            return;

        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
