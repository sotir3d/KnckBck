using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHandler : MonoBehaviour
{
    Rigidbody2D rigidBody;

    bool wobbleFinished = true;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") && (Mathf.Abs(rigidBody.velocity.x) > 2 || Mathf.Abs(rigidBody.velocity.y) > 2))
        {
            PlayerWobble(0.9f, 1.2f);
        }
    }

    public void PlayerWobble()
    {
        float minScale = Random.Range(0.7f, 0.9f);
        float maxScale = Random.Range(1.1f, 1.3f);

        PlayerWobble(minScale, maxScale);
    }

    public void PlayerWobble(float minScale, float maxScale)
    {
        if (wobbleFinished)
        {
            wobbleFinished = false;
            StartCoroutine(Wobble(minScale, maxScale));
        }
    }

    IEnumerator Wobble(float minScale, float maxScale)
    {
        Vector2 newScale = new Vector2(1,1);

        //float maxSize = 1.3f;
        //float minSize = 0.8f;

        float lerpSpeed = 65f;

        //always reset scale to default at the start
        transform.localScale = newScale;


        //for (int i = 0; i < iterations; i++)
        while(Mathf.Abs(transform.localScale.x - maxScale) > 0.001f || Mathf.Abs(transform.localScale.y - maxScale) > 0.001f)
        {
            newScale.x = Mathf.Lerp(newScale.x, maxScale, lerpSpeed * Time.deltaTime);
            newScale.y = Mathf.Lerp(newScale.y, maxScale, lerpSpeed * Time.deltaTime);

            transform.localScale = newScale;

            yield return null;
        }

        //for (int i = 0; i < iterations; i++)
        while (Mathf.Abs(transform.localScale.x - minScale) > 0.001f || Mathf.Abs(transform.localScale.y - minScale) > 0.001f)
        {
            newScale.x = Mathf.Lerp(newScale.x, minScale, lerpSpeed * Time.deltaTime);
            newScale.y = Mathf.Lerp(newScale.y, minScale, lerpSpeed * Time.deltaTime);

            transform.localScale = newScale;

            yield return null;
        }


        //for (int i = 0; i < iterations; i++)
        while (Mathf.Abs(transform.localScale.x - 1) > 0.001f || Mathf.Abs(transform.localScale.y - 1) > 0.001f)
        {
            newScale.x = Mathf.Lerp(newScale.x, 1f, lerpSpeed * Time.deltaTime);
            newScale.y = Mathf.Lerp(newScale.y, 1f, lerpSpeed * Time.deltaTime);

            transform.localScale = newScale;

            yield return null;
        }

        wobbleFinished = true;

    }
}
