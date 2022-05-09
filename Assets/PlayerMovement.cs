using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform platform;
    public GameManager gameManager;
    public float speed = 10f;
    public float maxVelocity = 20f;
    private Vector3 velocity = new Vector3(0, 0, 0);
    public float friction = 0.992f;
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
        if (gameManager.gameOver == false)
        {
            // if (Input.GetKey(KeyCode.A))
            // {
            //     if (velocity.x > -maxVelocity){
            //         velocity.x -= speed * Time.deltaTime;
            //     }
            // }
            // if (Input.GetKey(KeyCode.D))
            // {
            //     if (velocity.x < maxVelocity){
            //         velocity.x += speed * Time.deltaTime;
            //     }
            // }

            // rounded floats to int
            // int x = (int)Mathf.Round(velocity.x);



             Debug.Log(Mathf.Round(Input.GetAxis("Horizontal")));
            if (Input.anyKey){
                velocity.x += Mathf.Round(Input.GetAxis("Horizontal")) * speed * Time.deltaTime;
            }
            // velocity.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            // Input.Get("Vertical");

            if (Input.GetKey(KeyCode.S))
                if (velocity != -velocity)
                {
                    velocity = new Vector3(0, 0, 0);
                }
            transform.position += (velocity + new Vector3(0, 0, forwardSpeed))* Time.deltaTime;
            if (!Input.anyKey){
                velocity *= friction;
            }
            if (transform.position.y + 5f < platform.position.y)
            {
                gameManager.EndGame();
                // transform.position = new Vector3(0, platform.position.y + .5f, 0);
                // velocity = new Vector3(0, 0, 0);
            }
        }
    }
}
