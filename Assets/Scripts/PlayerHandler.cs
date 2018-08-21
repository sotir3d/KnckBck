using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHandler : MonoBehaviour
{
    Rigidbody2D rigidBody;

    Animator anim;

    float lastWobbledTime;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") && (Mathf.Abs(rigidBody.velocity.x) > 2 || Mathf.Abs(rigidBody.velocity.y) > 2))
        {
            if((Time.time - lastWobbledTime) > 0.2f)
            {
                lastWobbledTime = Time.time;
                //PlayerWobble();
            }
        }
    }


    public void PlayerWobble()
    {
        anim.SetTrigger("wobble");
    }
}
