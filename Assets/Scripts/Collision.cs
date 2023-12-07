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
        }

    }

    bool circleSquareCollision(float positionCircleX,float positionCircleY, float radius, float squarePosX, float squarePosY, float squareWidth, float squareHeight )
    {
        float testX = positionCircleX;
        float testY = positionCircleY;

        if (positionCircleX < squarePosX) // test left edge
        {
            testX = squarePosX;
        } else if (positionCircleX > squarePosX + squareWidth) //test right edge
        {
            testX= squarePosX + squareWidth;
        } 
        if(positionCircleY < squarePosY) // test top edge
        {
            testY = squarePosY;
        }else if (positionCircleY > squarePosY + squareHeight) // test bottom edge
        {
            testY = squarePosY + squareHeight;
        }
        //get distance from edges
        float distX = positionCircleX - testX;
        float distY = positionCircleY - testY;
        float distance = Mathf.Sqrt((distX * distX) + (distY * distY));

        if (distance < radius)
        {
            return true;
        }

        return false;
    }

}
