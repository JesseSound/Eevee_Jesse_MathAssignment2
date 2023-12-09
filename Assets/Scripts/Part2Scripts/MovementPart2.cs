using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementPart2 : MonoBehaviour
{
    public float moveSpeed;

    string objectName;

    KeyCode UP;
    KeyCode DOWN;
    KeyCode LEFT;
    KeyCode RIGHT;
    
    public float mASS;

    public float gravity = -9.8f;
    Vector3 velocity = Vector3.zero;
    //raycast for ground detection kek
    public bool isGrounded;
    public GameObject ground;
    // Start is called before the first frame update
    void Start()
    {
        //Get the name of the object the script is attached to. Hopefully, we will be able to condense movement
        objectName = gameObject.name;
        //CONNOR I KNOW YOU HATE STRINGS BUT I DON'T OK AT LEAST NOT IN THIS CONTEXT
        if (objectName == "Capsule")
        {
            UP = KeyCode.W;
            DOWN = KeyCode.S;
            RIGHT = KeyCode.D;
            LEFT = KeyCode.A;
        }
        else if (objectName == "Square")
        {
            UP = KeyCode.I;
            DOWN = KeyCode.K;
            RIGHT = KeyCode.L;
            LEFT = KeyCode.J;
        }
        else if (objectName == "Circle")
        {
            UP = KeyCode.T;
            DOWN = KeyCode.G;
            RIGHT = KeyCode.H;
            LEFT = KeyCode.F;
        }
    }
    bool IsGrounded()
    {
        float distanceToGround = Vector2.Distance(gameObject.transform.position, ground.transform.position);
        // Cast a ray downward and check for collision with the ground layer
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);
        Debug.DrawRay(transform.position, Vector2.down * 0.5f, Color.red);

       
        return true;
    }
    // Update is called once per frame
    void Update()
    {
        
        velocity = Vector3.zero; //reset velocity 


        //do the movement
        if (Input.GetKey(UP))
        {
            Debug.Log("UP!");
            velocity.y = 5.0f;
        }
        else if (Input.GetKey(DOWN))
        {
            Debug.Log("DOWN!");
            velocity.y = -5.0f;
        }
        else if (Input.GetKey(LEFT))
        {
            Debug.Log("LEFT!");
            velocity.x = -5.0f;
        }
        else if (Input.GetKey(RIGHT))
        {
            Debug.Log("RIGHT!");
            velocity.x = 5.0f;
        }

        isGrounded = IsGrounded();
        
        if (isGrounded)
        {
            Debug.Log("Hit!");
            velocity.y = 0.0f;
            gravity = 0;
            Debug.Log("Hit!");
        }
        else
        {

            float gravForce = mASS * gravity;
            velocity.y += gravForce * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;
        }
        
    }
}
