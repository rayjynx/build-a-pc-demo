using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenunew: MonoBehaviour
{
    public GameObject PauseMenu;
    public bool GameIsPaused;
    void Start()
    {
        //Close Menu
        GameIsPaused = false;
        PauseMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                ClosePauseMenu();
                GameIsPaused = !GameIsPaused;
            }
            else
            {
                OpenPauseMenu();
                GameIsPaused = !GameIsPaused;
            }
        }
    }
    public void OpenPauseMenu()
    {
        //Open Menu
        PauseMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }
    public void ClosePauseMenu()
    {
        //Close Menu
        PauseMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ResetLevel()
    {
        SceneManager.LoadScene("MainScene");
    }
}
