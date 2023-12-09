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

        velocity = Vector3.zero; //reset velocity 


        //do the movement
        if (Input.GetKey(UP) )
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




        
            float gravForce = mASS * gravity;
            velocity.y += gravForce * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;
    }
  
   }

