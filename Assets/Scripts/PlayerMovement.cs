using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector2 direction;
    Quaternion playerRotation;
    Rigidbody2D rigidBody;

    float angle;

    bool fired = false;

    // Use this for initialization
    void Start()
    {
        playerRotation = transform.rotation;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        playerRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = playerRotation;

        if (Input.GetButtonDown("Fire1"))
        {
            fired = true;
        }
    }

    private void FixedUpdate()
    {
        if(fired)
        {
            //rigidBody.velocity = new Vector2(0, 0);
            rigidBody.AddForce(transform.right * -5000);
            fired = false;
        }
    }
}
