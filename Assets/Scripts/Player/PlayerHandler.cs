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

    float lerpSpeed = 10;

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

    public IEnumerator MovePlayerIntoGoal(Vector2 goalPosition)
    {
        Debug.Log("moveplayer");
        Vector2 newPosition;

        transform.rotation = new Quaternion(0, 0, 0, 0);

        rigidBody.gravityScale = 0;

        rigidBody.velocity = Vector2.zero;
        rigidBody.angularVelocity = 0;

        newPosition = transform.position;

        for (int i = 0; i <= 100; i++)
        {
            //transform.Rotate(Vector3.forward * 30);

            newPosition.x = Mathf.Lerp(newPosition.x, goalPosition.x, lerpSpeed * Time.deltaTime);
            newPosition.y = Mathf.Lerp(newPosition.y, goalPosition.y, lerpSpeed * Time.deltaTime);
            transform.position = newPosition;


            //yield return new WaitForSeconds(0.03f);
            yield return new WaitForEndOfFrame();
        }


        rigidBody.gravityScale = 1;

    }
}
