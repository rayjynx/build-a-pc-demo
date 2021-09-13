using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // exit button script
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}
