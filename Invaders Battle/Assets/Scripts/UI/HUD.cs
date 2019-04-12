using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    private bool gamePause = false;

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
	}

    private void PauseGame()
    {
        Time.timeScale = 0;
        gamePause = true;
    }

    private void UnpauseGame()
    {
        Time.timeScale = 1;
        gamePause = false;
    }

}
