using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusMovement : MonoBehaviour

{
    public GameObject cactus;
    public GameObject robot;

    private const float DistanceOfInteraction = 2.0f;
    public bool isIdle = true;
    // Start is called before the first frame update
    void Start()
    {
        cactus=GameObject.Find("Cactus");
        robot=GameObject.Find("Robot Kyle");

        var animator = cactus.GetComponent<Animator>();
        animator.Play("Idle");
     
        isIdle = true;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = cactus.transform.position;
        float x1=pos.x, y1=pos.y, z1=pos.z;
        pos = robot.transform.position;
        float x2=pos.x, y2=pos.y, z2=pos.z;
        float deltaX = x2 - x1;
        float deltaY = y2 - y1;
        float deltaZ = z2 - z1;
        float distance = (float) Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
        

        if (distance < DistanceOfInteraction)
        {
            
            if (isIdle == true)
            {
                //play other animation
                cactus.GetComponent<Animator>().Play("Attack");
                isIdle = false;
            }
        }
        else
        {
            if (isIdle == false)
            {
                //play idle animation
                cactus.GetComponent<Animator>().Play("Idle");
                isIdle = true;
            }
        }
    }
}
