using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impulseForce : MonoBehaviour
{
    MovementPart3 mass;

    private void Start()
    {
        mass = GetComponent<MovementPart3>();
    }
    public bool isClickedOn()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float dist = Vector2.Distance(mousePosition, gameObject.transform.position);
        if (Input.GetMouseButtonDown(0) && dist <= 0.5f)
        {
            Debug.Log("Youch!");
            float impForce = 5.0f;
            float impulse = impForce * Time.deltaTime;
            float finalVelocity = (mass.gravity + (impulse / mass.mASS) * Time.deltaTime);

            transform.position -= new Vector3(0, finalVelocity, 0);
        }
        return dist <= 0.5;
    }
    private void Update()
    {
       
        
    }
    
}
