using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuWatcher : MonoBehaviour
{
    // Start is called before the first frame update
    private bool showGameMenu = false;
    private Vector3 menuPos;

    private Vector3 mousePos;

    public GameObject spawner;
    public GameObject platform;

    public Camera camera;

    private Rect menuBounds;

    private string[] selectionArr = { "0°", "15°", "45°", "90°", "-15°", "-45°" };

    private List<GameObject> objs;

    void Start()
    {
        menuPos = new Vector3();
        mousePos = new Vector3();
        menuBounds = new Rect(0, 0, 0, 0);
        objs = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void setupMenu()
    {
        showGameMenu = true;
        menuPos = mousePos;
        menuBounds = new Rect(menuPos.x, menuPos.y, menuPos.x + 200, menuPos.y - 180);
    }

    void OnGUI()
    {
        mousePos = Input.mousePosition;
        if (Input.GetMouseButtonDown(1) && !showGameMenu)
        {
            setupMenu();
        }

        if (showGameMenu)
        {
            float x = menuPos.x;
            float y = Screen.height - menuPos.y;
            int angle = -1;
            GUI.Box(new Rect(x, y, 200, 340), "");
            GUI.Label(new Rect(x + 10, y + 10, 100, 50), "New Spawner");
            if (GUI.Button(new Rect(x + 180, y, 20, 20), "X"))
            {
                showGameMenu = false;
                return;
            }
            if (GUI.Button(new Rect(x + 20, y + 38, 150, 20), "Bass Drum"))
            {
                Debug.Log("You Clicked Here: Bass Drum");
                GameObject g = Instantiate(spawner, camera.ScreenToWorldPoint(new Vector3(menuPos.x, menuPos.y, 15)), transform.rotation * Quaternion.Euler(90f, 0f, 0f));
                g.transform.Rotate(0f, 0f, 0f);
                showGameMenu = false;
                objs.Add(g);
                return;
            }
            // Make the second button to load second level
            if (GUI.Button(new Rect(x + 20, y + 68, 150, 20), "Snare"))
            {
                Debug.Log("You Clicked Here: Snare");
                GameObject g = Instantiate(spawner, camera.ScreenToWorldPoint(new Vector3(menuPos.x, menuPos.y, 15)), transform.rotation * Quaternion.Euler(90f, 0f, 0f));
                g.transform.Rotate(0f, 0f, 0f);
                showGameMenu = false;
                objs.Add(g);
                return;
            }

            if (GUI.Button(new Rect(x + 20, y + 98, 150, 20), "Cymbal"))
            {
                Debug.Log("You Clicked Here: Cymbal");
                GameObject g = Instantiate(spawner, camera.ScreenToWorldPoint(new Vector3(menuPos.x, menuPos.y, 15)), transform.rotation * Quaternion.Euler(90f, 0f, 0f));
                g.transform.Rotate(0f, 0f, 0f);
                showGameMenu = false;
                objs.Add(g);
                return;
            }

            GUI.Label(new Rect(x + 10, y + 130, 100, 50), "New Platform");
            angle = GUI.SelectionGrid(new Rect(x + 20, y + 158, 150, 100), angle, selectionArr, 2);
            if (angle != -1)
            {
                Debug.Log("You Clicked Here: " + selectionArr[angle]);
                GameObject g = Instantiate(platform, camera.ScreenToWorldPoint(new Vector3(menuPos.x, menuPos.y, 15)), transform.rotation * Quaternion.Euler(90f, 0f, -float.Parse(selectionArr[angle].Remove(selectionArr[angle].Length - 1, 1))));
                g.transform.Rotate(0f, 0f, 0f);
                showGameMenu = false;
                objs.Add(g);
                return;
            }
            if (GUI.Button(new Rect(x + 20, y + 282, 70, 20), "Play"))
            {
                Debug.Log("You Clicked Here: Play");
                return;
            }
            if (GUI.Button(new Rect(x + 100, y + 282, 70, 20), "Pause"))
            {
                Debug.Log("You Clicked Here: Pause");
                return;
            }

            if (GUI.Button(new Rect(x + 20, y + 308, 150, 20), "Clear All Objects"))
            {
                Debug.Log("You Clicked Here: Clear");
                foreach (GameObject obj in objs)
                {
                    Destroy(obj);
                }
                return;
            }
        }
    }


}
