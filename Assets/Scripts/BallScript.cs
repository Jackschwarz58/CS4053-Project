/*
---Sphere Movement Script---
Version: 0.0.1
Last Modified: 3/19/21 - William
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class BallScript : MonoBehaviour
{

    private Rigidbody body;
    private Renderer render;

    public float yForce = 400.0f;
    private Vector3 initVel;
    private Vector3 lastVel;

    //use this for initialization  

    void Start()
    {
        body = GetComponent<Rigidbody>();
        render = GetComponent<Renderer>();
        body.velocity = initVel;
        render.material.color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    void Update()
    {  //Update is called once per frame  

        float y = 0.0f;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            y = yForce;
        }

        body.AddForce(0.0f, y, 0.0f);
        lastVel = body.velocity;
    }

    private void OnCollisionEnter(Collision c)
    {
        render.material.color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
}