using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    public int BPM = 60; // Beats per minute
    private int beat = -1;

    public List<AudioClip> ogSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        beat++;
        if (Input.GetKey(KeyCode.C))
        {
            ogSound = new List<AudioClip>();
            GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
            foreach (GameObject s in spawners)
            {
                if (ogSound.Count <= spawners.Length)
                    ogSound.Add(s.GetComponent<DropSphere>().sound);
            }

            if (Input.GetKey(KeyCode.T))
            {
                foreach (GameObject s in spawners)
                {
                    s.GetComponent<DropSphere>().sound = Resources.Load<AudioClip>("Sounds/tim");
                }
            }
            if (Input.GetKey(KeyCode.O))
            {
                foreach (GameObject s in spawners)
                {
                    s.GetComponent<DropSphere>().sound = Resources.Load<AudioClip>("Sounds/oof");
                }
            }
            if (Input.GetKey(KeyCode.Equals))
            {
                if (ogSound.Count > 0)
                {
                    Debug.Log("Changing the sound back... You're no fun.... ");
                    for (int i = 0; i < spawners.Length; ++i)
                    {
                        spawners[i].GetComponent<DropSphere>().sound = ogSound[i];
                    }
                }
            }
        }
    }


    public int GetBeat()
    {
        return beat;
    }
}
