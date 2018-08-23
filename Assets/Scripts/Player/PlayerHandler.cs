using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHandler : MonoBehaviour
{
    GameObject gameManager;

    Vector2 startPosition;
    Quaternion startRotation;

    Rigidbody2D rigidBody;

    Animator anim;

    float lastWobbledTime;

    TrailRenderer trail;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        trail = GetComponent<TrailRenderer>();
        anim = GetComponent<Animator>();
        startPosition = transform.position;
        startRotation = transform.rotation;
        
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    public void Death()
    {
        trail.enabled = false;
        rigidBody.velocity = Vector2.zero;
        rigidBody.angularVelocity = 0;
        transform.rotation = startRotation;
        transform.position = startPosition;

        //avoids the trail going after the player when resetting to default location
        trail.Clear();
        trail.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Wall") && (Mathf.Abs(rigidBody.velocity.x) > 2 || Mathf.Abs(rigidBody.velocity.y) > 2))
        //{
        //    if((Time.time - lastWobbledTime) > 0.2f)
        //    {
        //        lastWobbledTime = Time.time;
        //        //PlayerWobble();
        //    }
        //}
    }


    public void PlayerWobble()
    {
        anim.SetTrigger("wobble");
    }
}
