using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collision : MonoBehaviour
{

    public GameObject circle;
    public GameObject capsule;
    public GameObject square;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 positionCirc = circle.transform.position;
        float positionCircX = circle.transform.position.x;
        float positionCircY = circle.transform.position.y;

        Vector2 positionCaps = capsule.transform.position;
        Vector2 positionSqr = square.transform.position;
        float radius1 = circle.transform.localScale.x * 0.5f;
        float sqrPosX = square.transform.position.x;
        float sqrPosY = square.transform.position.y;
        float sqrH = square.transform.localScale.x;//square height
        float sqrW = square.transform.localScale.y;//square width

        bool circlSqrHit = circleSquareCollision(positionCircX, positionCircY, radius1, sqrPosX, sqrPosY, sqrH, sqrW);
        if (circlSqrHit)
        {
            Debug.Log("Hit Square and Circle");
            circle.GetComponent<SpriteRenderer>().color = Color.green;
            square.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            circle.GetComponent<SpriteRenderer>().color = Color.red;
            square.GetComponent<SpriteRenderer>().color = Color.red;
        }

    }

    bool circleSquareCollision(float positionCircleX,float positionCircleY, float radius, float squarePosX, float squarePosY, float squareWidth, float squareHeight )
    {
        float closestX = Mathf.Clamp(positionCircleX, squarePosX - squareWidth / 2, squarePosX + squareWidth / 2);
        float closestY = Mathf.Clamp(positionCircleY, squarePosY - squareHeight / 2, squarePosY + squareHeight / 2);

        // Calculate the distance between the circle's center and the closest point on the square
        float distance = Vector2.Distance(new Vector2(positionCircleX, positionCircleY), new Vector2(closestX, closestY));

        // Check for collision
        if (distance < radius)
        {
            return true;
        }

        return false;
    }

}
