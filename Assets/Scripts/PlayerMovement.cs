using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector2 direction;
    Quaternion playerRotation;
    Rigidbody2D rigidBody;

    float angle;
    float torque = 200f;
    float force = 5000;

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
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition /*Input.GetTouch(0).position*/) - transform.position;
        
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        playerRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = playerRotation;

        if (Input.GetButtonDown("Fire1"))
        {
            fired = true;
        }
    }

    private void FixedUpdate()
    {
        if (fired)
        {
            //rigidBody.velocity = new Vector2(0, 0);
            rigidBody.AddForce(direction.normalized * -force);

            if (angle > 0 && angle < 90)
                rigidBody.AddTorque(-torque);
            else if (angle > 90 && angle < 180)
                rigidBody.AddTorque(torque);
            else if (angle < 0 && angle > -90)
                rigidBody.AddTorque(torque);
            else if (angle < -90 && angle > -180)
                rigidBody.AddTorque(-torque);
            fired = false;
        }
    }
}
