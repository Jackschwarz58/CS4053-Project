using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSphere : MonoBehaviour
{
    public GameObject sphere;
    public GameObject masterController;
    public AudioClip sound;

    public int dropBeat; // Drops an object every x beats
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int beat = masterController.GetComponent<MasterController>().GetBeat();
        if(beat % dropBeat == 0)
        {
            DropBall();
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DropBall();
        }
    }

    void DropBall()
    {
        GameObject ball = Instantiate(sphere, transform.position - new Vector3(0, 1.5f, 0), transform.rotation);
        ball.GetComponent<Rigidbody>().AddForce(new Vector3(0, -5f, 0));
        ball.GetComponent<BallScript>().sound = sound;
    }
}
