using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Canvas creditsCanvas;

    private void Start()
    {
        creditsCanvas.enabled = false;
    }

    public void OpenCredits()
    {
        creditsCanvas.enabled = true;
    }
    
    public void CloseCredits()
    {
        creditsCanvas.enabled = false;
    }
}
