using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Collision : MonoBehaviour
{

    public GameObject circle;
    public GameObject capsule;
    public GameObject square;

    public GameObject capsuleTop;
    public GameObject capsuleBot;

    public GameObject projection;

    








    // Start is called before the first frame update
    void Start()
    {
        circle.GetComponent<SpriteRenderer>().color = Color.red;
        square.GetComponent<SpriteRenderer>().color = Color.red;
        capsule.GetComponent<SpriteRenderer>().color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        //circle info
        Vector2 positionCirc = circle.transform.position;
        float positionCircX = circle.transform.position.x;
        float positionCircY = circle.transform.position.y;

        Vector2 positionCaps = capsule.transform.position;
        Vector2 positionSqr = square.transform.position;
        float radius1 = circle.transform.localScale.x * 0.5f;

        //square info
        float sqrPosX = square.transform.position.x;
        float sqrPosY = square.transform.position.y;
        float sqrH = square.transform.localScale.x;//square height
        float sqrW = square.transform.localScale.y;//square width


        //capsule info
        Vector3 capsPos = capsule.transform.position;
        float capsulePosX = capsule.transform.position.x;
        float capsulePosY = capsule.transform.position.y;
        float capsuleH = capsule.transform.localScale.y; //capsule height
        float capsuleW = capsule.transform.localScale.x; //capsule width




        bool circlSqrHit = circleSquareCollision(positionCircX, positionCircY, radius1, sqrPosX, sqrPosY, sqrH, sqrW);
        //bool capsCircleHit = circleCapsuleCollision(positionCirc,radius1, capsPos, );
        if (circlSqrHit)
        {
            Debug.Log("Hit Square and Circle");
            circle.GetComponent<SpriteRenderer>().color = Color.green;
            square.GetComponent<SpriteRenderer>().color = Color.green;
        }
        //else if (capsCircleHit)
        //{
        //    circle.GetComponent<SpriteRenderer>().color = Color.green;
        //    capsule.GetComponent<SpriteRenderer>().color = Color.green;
        //}

        else
        {
            circle.GetComponent<SpriteRenderer>().color = Color.red;
            capsule.GetComponent<SpriteRenderer>().color = Color.red;
            square.GetComponent<SpriteRenderer>().color = Color.red;
        }

        Vector3 top, bot;
        CapsulePoints(capsule.transform.position, capsule.transform.up, capsuleH * 0.5f, out top, out bot) ;
        capsuleTop.transform.position = top;
        capsuleBot.transform.position = bot;
    }

    bool circleSquareCollision(float positionCircleX, float positionCircleY, float radius, float squarePosX, float squarePosY, float squareWidth, float squareHeight)
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


    void CapsulePoints(Vector3 position, Vector3 direction, float halfHeight, out Vector3 top, out Vector3 bot)
    {
        top = position + direction * halfHeight;
        bot = position - direction * halfHeight;
    }
    bool circleCapsuleCollision( Vector3 positionCircle, float circleRadius, Vector3 positionCapsule, float capsuleRadius, Vector3 direction, float capsuleHalfHeight)
    {

        Vector3 top, bot;
        CapsulePoints(capsule.transform.position, capsule.transform.up, capsule.transform.localScale.y * 0.5f, out top, out bot);
        ProjectPointLine(projection.transform.position, top, bot);
        return false;
    }

    Vector3 ProjectPointLine(Vector3 P, Vector3 A, Vector3 B)
    {
        Vector3 AB = B - A;
        Vector3 AP = P - A;
        float t = Vector3.Dot(AB, AP) / Vector3.Dot(AB, AB);
        t = Mathf.Clamp(t, 0.0f, 1.0f);
        return A + AB * t;
    }


    bool CheckCollisionCircles(Vector3 position1, float radius1, Vector3 position2, float radius2)
    {
        // Distance between position 1 and position 2
        float distance = (position1 - position2).magnitude;

        // Direction from to position 2 to position 1
        Vector3 direction = (position1 - position2).normalized;

        // Sum of radii
        float radiiSum = radius1 + radius2;

        // Collision if distance between circles is less than the sum of their radii!
        bool collision = distance < radiiSum;
        //if (collision)
        //{
        //    // calculate mtv only if there's a collision
        //    float depth = radiisum - distance;
        //    mtv = direction * depth;
        //}
        //else
        //{
        //    mtv = vector3.zero;
        //}
        return collision;
    }





}
