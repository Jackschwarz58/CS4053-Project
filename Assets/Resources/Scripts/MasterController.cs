using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    public int BPM = 60; // Beats per minute
    private int beat = -1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        beat++;
    }


    public int GetBeat()
    {
        return beat;
    }
}
