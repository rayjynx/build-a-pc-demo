using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnMouseClick : MonoBehaviour
{
    void Update()
    {
        // If the left mouse button is pressed down
        if (Input.GetMouseButtonDown(0) == true)
        {
            GetComponent<AudioSource>().Play();
        }
        // If the left mouse button is released
        if (Input.GetMouseButtonUp(0) == true)
        {
            GetComponent<AudioSource>().Stop();
        }
    }
}
