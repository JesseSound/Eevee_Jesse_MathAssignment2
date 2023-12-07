using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement: MonoBehaviour
{
    public float moveSpeed;

    string objectName;

    KeyCode UP;
    KeyCode DOWN;
    KeyCode LEFT;
    KeyCode RIGHT;
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

    // Update is called once per frame
    void Update()
    {
        //setting up Horizontal and Vertical movement
        float horizontalInput = 0f;
        float verticalInput = 0f;

        //do the movement
        if (Input.GetKey(UP))
        {
            Debug.Log("UP!");
            verticalInput = 1f;
        }
        else if (Input.GetKey(DOWN))
        {
            Debug.Log("DOWN!");
            verticalInput = -1f;
        }
        else if (Input.GetKey(LEFT))
        {
            Debug.Log("LEFT!");
            horizontalInput = -1f;
        }
        else if (Input.GetKey(RIGHT))
        {
            Debug.Log("RIGHT!");
            horizontalInput = 1f;
        }

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

        // Normalize the vector 
        movement.Normalize();

        // Move the object based on the input and speed
        transform.position += movement * moveSpeed * Time.deltaTime;


    }
}
