using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameManager gameManager;

    public Canvas levelCompleteCanvas;
    public Button nextLevelButton;    
    
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        levelCompleteCanvas.enabled = false;
        ToggleNextLevelButton();
    }

    public void LevelComplete()
    {
        levelCompleteCanvas.enabled = true;
    }

    void ToggleNextLevelButton()
    {
        //if (SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).IsValid())
        
        if (gameManager.CheckIfNextLevelAvailable())
        {
            Debug.Log("if");
            nextLevelButton.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("else");
            nextLevelButton.gameObject.SetActive(false);
        }
    }
}
