using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera topDown;
    public Camera main;
    // Start is called before the first frame update
    void Start()
    {
        main.GetComponent<Camera>().enabled = true;
        topDown.GetComponent<Camera>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            main.GetComponent<Camera>().enabled = !main.GetComponent<Camera>().enabled;
            topDown.GetComponent<Camera>().enabled = !topDown.GetComponent<Camera>().enabled;
        }
    }
}
