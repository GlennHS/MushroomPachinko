using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Canvas creditsCanvas, instructionsCanvas;
    public TMP_Text dropIndicatorText;

    private void Start()
    {
        creditsCanvas.enabled = false;
        instructionsCanvas.enabled = false;
    }

    private void Update()
    {
        if (GameManager.instance.ballDropping)
            dropIndicatorText.text = "Drop In Progress!";
        else
            dropIndicatorText.text = "Click Here To Drop!";
    }

    public void OpenCredits()
    {
        creditsCanvas.enabled = true;
    }
    
    public void CloseCredits()
    {
        creditsCanvas.enabled = false;
    }
    
    public void OpenInstructions()
    {
        instructionsCanvas.enabled = true;
    }
    
    public void CloseInstructions()
    {
        instructionsCanvas.enabled = false;
    }

    public void RestartGame()
    {
        GameManager.instance.Restart();
    }
}
