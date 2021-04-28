using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public float speed = 10.0f;
    public float multiplier = 2.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float adjSpeed = speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            adjSpeed = speed * multiplier;
        }

        transform.position = transform.position + new Vector3(horizontalInput * adjSpeed * Time.deltaTime, verticalInput * adjSpeed * Time.deltaTime, 0);
    }
}