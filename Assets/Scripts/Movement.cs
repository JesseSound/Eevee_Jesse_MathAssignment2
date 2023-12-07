using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    string objectName;
    // Start is called before the first frame update
    void Start()
    {
        //Get the name of the object the script is attached to. Hopefully, we will be able to condense movement
         objectName = gameObject.name; 
    }

    // Update is called once per frame
    void Update()
    {
        
        if(objectName == "Capsule")
        {

        } else if (objectName == "Square")
        {

        }else if(objectName == "Circle")
        {

        }


    }
}
