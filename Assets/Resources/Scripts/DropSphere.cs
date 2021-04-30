using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSphere : MonoBehaviour
{
    public GameObject sphere;

    public GameObject masterController;
    public AudioClip sound;

    public bool paused;

    public int dropBeat; // Drops an object every x beats
    void Start()
    {
        masterController = GameObject.Find("Old Timer Rickward");
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {

        int beat = masterController.GetComponent<MasterController>().GetBeat();
        bool release = masterController.GetComponent<MasterController>().drop;
        if (beat % dropBeat == 0 && release)
        {
            DropBall();
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            DropBall();
        }
    }

    void DropBall()
    {
        if (!paused)
        {
            GameObject ball = Instantiate(sphere, transform.position - new Vector3(0, 1.5f, 0), transform.rotation);
            ball.GetComponent<Rigidbody>().AddForce(new Vector3(0, -5f, 0));
            ball.GetComponent<BallScript>().sound = sound;

        }
    }
}
