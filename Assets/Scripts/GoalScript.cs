using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public GameObject gameManager;

    private void Start()
    {
        //gameManager = GameObject.FindGameObjectWithTag("GameManager");
        Debug.Log("start");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.GetComponent<GameManager>().LevelComplete();

        }
    }
}
