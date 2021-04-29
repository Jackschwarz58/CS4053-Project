/*
---Sphere Movement Script---
Version: 0.0.1
Last Modified: 3/18/21 - Jack
*/ 
using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
  
[RequireComponent (typeof(Rigidbody))]  
  
public class move : MonoBehaviour {  
  
    private Rigidbody body;
    private Renderer render;

    public float yForce = 400.0f;  
    private bool isColliding = false;
    private Vector3 initVel;
    private Vector3 lastVel;
    public int bounceAmt;
    public float bounceVelOffset = 10f;
    public bool demo = false;
  
    //use this for initialization  

    void Start () {  
          body = GetComponent<Rigidbody>();
          render = GetComponent<Renderer>();
          body.velocity = initVel;
          render.material.color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
          bounceAmt = 0;
    }  

    void Update () {  //Update is called once per frame  
        isColliding = false; //This is to prevent the ball from registering multiple collisions as it lands

        float y = 0.0f;  
        if (Input.GetKeyDown (KeyCode.Space)) {  
            y = yForce;  
            bounceAmt = 0;
        }  
  
        body.AddForce(0.0f, y, 0.0f); 
        lastVel = body.velocity;
    }  

    private void OnCollisionEnter(Collision c) {
        
        if(isColliding) return;
        isColliding = true;
        
            if(demo) {
                if(bounceAmt > 5) return;
            }
            Bounce(c.contacts[0].normal);
        
        render.material.color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    private void Bounce(Vector3 cNorm)
    { 
        float speed = lastVel.magnitude;
        Vector3 direction = Vector3.Reflect(lastVel.normalized, cNorm);
        float bounceVel = bounceVelOffset;// - bounceAmt;

        if(demo) {
            bounceVelOffset = 5f;
            bounceVel -= bounceAmt;
        }
        
        body.velocity = direction * Mathf.Max(speed, bounceVel);
        bounceAmt++;
    }
} 