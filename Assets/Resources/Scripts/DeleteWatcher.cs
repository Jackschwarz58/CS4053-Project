using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteWatcher : MonoBehaviour
{
    private Rigidbody body;
    void Start()
    {
        body = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            if (GetComponent<BallScript>())
            {
                Destroy(GetComponent<BallScript>());
            }
            Destroy(this.gameObject);
            Destroy(this);
            Destroy(body);

            return;
        }
    }
}
