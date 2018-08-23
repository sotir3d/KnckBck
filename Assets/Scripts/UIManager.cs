using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Canvas levelCompleteCanvas;
    
    private void Start()
    {
        levelCompleteCanvas.enabled = false;
    }

    public void LevelComplete()
    {
        levelCompleteCanvas.enabled = true;
    }
}
