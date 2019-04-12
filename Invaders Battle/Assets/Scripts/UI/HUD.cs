using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public Player red;
    public Player Blue;

    public GameObject[] pauseChild;
    public GameObject[] EndChild;
    private bool gamePause = false;
    public Text winner;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (!gamePause)
            {
                PauseGame();
            }
            else if (gamePause)
            {
                UnpauseGame();
            }


        }

        if (red.Health <= 0 || Blue.Health <= 0)
        {
            Endgame();
            if (red.Health <= 0)
            {
                winner.text = "Blue Wins"; 
            }
            else
            {
                winner.text = "Red Wins";
            }
        }
	}

    private void PauseGame()
    {
        Time.timeScale = 0;
        gamePause = true;
        foreach (GameObject item in pauseChild)
        {
            item.SetActive(true);
        }

    }

    private void UnpauseGame()
    {
        Time.timeScale = 1;
        gamePause = false;
        foreach (GameObject item in pauseChild)
        {
            item.SetActive(false);
        }
    }

    private void Endgame()
    {
        Time.timeScale = 0;
        foreach (GameObject item in EndChild)
        {
            item.SetActive(true);
        }
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
    }

}
