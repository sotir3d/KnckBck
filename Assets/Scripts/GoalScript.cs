using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public GameObject gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("trigger");
            StartCoroutine(collision.gameObject.GetComponent<PlayerHandler>().MovePlayerIntoGoal(transform.position));

            gameManager.GetComponent<GameManager>().LevelComplete();

        }
    }
}
