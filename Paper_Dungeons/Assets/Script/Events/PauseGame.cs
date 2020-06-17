﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Xml.Linq;

public class PauseGame : MonoBehaviour
{
    //public GameObject pausePanel;

    void Start()
    {
        //pausePanel.SetActive(false);
        //Time.timeScale = 0;
    }
    void Update()
    {

    }

    public void Pause()
    {
        Time.timeScale = 0;
        //pausePanel.SetActive(true);
        //Disable scripts that still work while timescale is set to 0
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        //pausePanel.SetActive(false);
        //enable the scripts again
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);

    }

    public void QuitGame()
    {
       Application.Quit();

    }

}