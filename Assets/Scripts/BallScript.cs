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
    public GameObject ripple;
    private Rigidbody body;
    private Renderer render; 

    public float yForce = 400.0f;
    private Vector3 initVel;
    private Vector3 lastVel;
    //public Transform ripple;

    //use this for initialization  

    void Start()
    {   
        ripple.GetComponent<ParticleSystem>().enableEmission = false;
        body = GetComponent<Rigidbody>();
        render = GetComponent<Renderer>();
        body.velocity = initVel;
        render.material.color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        //ripple.GetComponent<ParticleSystem>().enableEmission = false;
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
        ripple.GetComponent<ParticleSystem>().enableEmission = true;
        ripple.GetComponent<ParticleSystem>().startColor = render.material.color;
        render.material.color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        GameObject g = Instantiate(ripple, c.gameObject.transform.position, transform.rotation);
        StartCoroutine(deleteRipple(g));
    }

    IEnumerator deleteRipple(GameObject g)
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(g);
    }


}