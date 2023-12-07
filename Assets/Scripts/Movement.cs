using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement: MonoBehaviour
{
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
       
        

        if (Input.GetKeyDown(UP))
        {
            Debug.Log("UP!");
        }
        else if (Input.GetKeyDown(DOWN))
        {
            Debug.Log("DOWN!");
        }
        else if (Input.GetKeyDown(LEFT))
        {
            Debug.Log("LEFT!");
        }
        else if (Input.GetKeyDown(RIGHT))
        {
            Debug.Log("RIGHT!");
        }
    }
}
