using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform platform;
    public float speed = 5f;
    public float maxVelocity = 10f;
    private Vector3 velocity = new Vector3(0, 0, 0);
    public float friction = 0.9f;
    public float forwardSpeed = 5f;
    // public PlayerMovement movement;
    // public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        // Mathf.Clamp(1000f, 400f, 0.5f);
        transform.position = new Vector3(0, platform.position.y + .5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (velocity.x > -maxVelocity){
                velocity.x -= speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (velocity.x < maxVelocity){
                velocity.x += speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.S))
            if (velocity != -velocity)
            {
                velocity = new Vector3(0, 0, 0);
            }
        transform.position += (velocity + new Vector3(0, 0, forwardSpeed))* Time.deltaTime;
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)){
            velocity *= friction;
        }
        if (transform.position.y + 5f < platform.position.y)
        {
            transform.position = new Vector3(0, platform.position.y + .5f, 0);
            velocity = new Vector3(0, 0, 0);
        }
    }
}
