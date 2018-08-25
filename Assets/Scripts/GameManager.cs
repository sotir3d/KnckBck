using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    UIManager uiManager;

    private void Start()
    {
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }

    public void LevelComplete()
    {

        Time.timeScale = 0f;
        uiManager.LevelComplete();
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        //checks if the next scene index exists
        if (CheckIfNextLevelAvailable())
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public bool CheckIfNextLevelAvailable()
    {
        Debug.Log(SceneManager.GetSceneByName("Level1").IsValid());
        //if (SceneManager.GetSceneByName("Level" + (SceneManager.GetActiveScene().buildIndex + 1)).IsValid())
        if (SceneManager.GetActiveScene().buildIndex < (SceneManager.sceneCountInBuildSettings - 1))
        {
            return true;
        }

        return false;
    }
}
