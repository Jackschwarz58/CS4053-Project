using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSphere : MonoBehaviour
{
    public GameObject sphere;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(sphere, transform.position - new Vector3(0, 1.5f, 0), transform.rotation).GetComponent<Rigidbody>().AddForce(new Vector3(0, -5f, 0));
        }
    }
}
