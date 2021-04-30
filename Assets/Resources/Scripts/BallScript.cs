/*
---Sphere Movement Script---
Version: 0.0.3
Last Modified: 4/25/21 - William
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

    public bool debugOut = false;
    private Vector3 initVel;
    private Vector3 lastVel;

    Material emitColor;

    GameObject lightGameObject;

    Light lightComp;

    public AudioClip sound;


    //use this for initialization  

    void Start()
    {
        var em = ripple.GetComponent<ParticleSystem>().emission;
        em.enabled = false;

        body = GetComponent<Rigidbody>();
        render = GetComponent<Renderer>();
        emitColor = GetComponent<Renderer>().material;
        body.velocity = initVel;
        render.material.color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        lightGameObject = new GameObject();
        lightComp = lightGameObject.AddComponent<Light>();
        lightGameObject.transform.position = new Vector3(body.transform.position.x, body.transform.position.y, body.transform.position.z);

        setEmissionsColor(render.material.color);
    }

    void Update()
    {  //Update is called once per frame  
        float y = 0.0f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            y = yForce;
        }
        checkInput();

        body.AddForce(0.0f, y, 0.0f);
        lastVel = body.velocity;

        lightGameObject.transform.position = new Vector3(body.transform.position.x, body.transform.position.y, body.transform.position.z);
        if (transform.position.y < -5)
        {
            Destroy(lightComp);
            Destroy(lightGameObject);
            Object.Destroy(gameObject);
        }


    }
    IEnumerator deleteRipple(GameObject g)
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(g);
    }
    private void OnCollisionEnter(Collision c)
    {

        Color color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        render.material.color = color;

        setEmissionsColor(color);

        var em = ripple.GetComponent<ParticleSystem>().emission;
        var emMain = ripple.GetComponent<ParticleSystem>().main;

        em.enabled = true;
        emMain.startColor = render.material.color;

        GameObject g = Instantiate(ripple, c.gameObject.transform.position, transform.rotation);
        StartCoroutine(deleteRipple(g));
        AudioSource.PlayClipAtPoint(sound, 0.9f * Camera.main.transform.position + .1f * transform.position, 10f);
    }

    private void setEmissionsColor(Color color)
    {
        float adjustedIntensity = 11 - (0.4169F);
        if (debugOut)
        {
            Debug.Log("Setting Color: " + color);
            Debug.Log("Setting Color Intensity: " + adjustedIntensity);
        }
        lightComp.color = color;
        color *= Mathf.Pow(2.0F, adjustedIntensity);
        emitColor.SetColor("_EmissionColor", color);
    }

    private void checkInput()
    {
        if (Input.GetKeyDown(KeyCode.Period))
        {
            lightComp.intensity += 1;
        }
        else if (Input.GetKeyDown(KeyCode.Comma))
        {
            lightComp.intensity -= 1;
        }
        else if (Input.GetKeyDown(KeyCode.Equals))
        {
            transform.localScale += new Vector3(.1f, .1f, .1f);
        }
        else if (Input.GetKeyDown(KeyCode.Minus))
        {
            if (transform.localScale.x > 0.3f)
            {
                transform.localScale -= new Vector3(.1f, .1f, .1f);
            }

        }

    }
}