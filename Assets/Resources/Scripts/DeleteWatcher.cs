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
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        if (Application.targetFrameRate != target)
            Application.targetFrameRate = target;
    }
    float deltaTime = 0.0f;

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(1f, 1f, 1f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }

    public int target = 60;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = target;
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
