using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsHelper : MonoBehaviour
{
    public GameObject instructionsMenu;
    public GameObject pauseButton;

    private bool hasTriggered = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasTriggered && collision.gameObject.name == "Instructions")
        {
            
            instructionsMenu.SetActive(true);
            
            pauseButton.SetActive(false);
            
            PauseGame();

            hasTriggered = true;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0F;
    }
}
