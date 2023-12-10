using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPart3 : MonoBehaviour
{
    public float moveSpeed;

    string objectName;

    KeyCode UP;
    KeyCode DOWN;
    KeyCode LEFT;
    KeyCode RIGHT;

    public float mASS;

    public float gravity = -9.8f;
    public float impForce;
    Vector3 velocity = Vector3.zero;


    groundCollision groundDetect;
    

    // Start is called before the first frame update
    void Start()
    {
        groundDetect = GetComponent<groundCollision>();
        
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
    void FixedUpdate()
    {

        //velocity = Vector3.zero; //reset velocity 
        velocity = Vector3.zero;

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
        
            
        

        if (groundDetect.groundHit)
        {
            //velocity.y= 0;
           
        }

        float gravForce = mASS * gravity;
        velocity.y += gravForce * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
       
        
    }
    private void Update()
    {
        
    
    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    float dist = Vector2.Distance(mousePosition, gameObject.transform.position);
        if (Input.GetMouseButtonDown(0) && dist <= 0.5f)
        {

            
            float impulse = impForce * Time.deltaTime;
            float velocityF = (-9.8f - impulse) / mASS;
            transform.position -= new Vector3(0.0f, velocityF, 0.0f);
        }
}
   




}
