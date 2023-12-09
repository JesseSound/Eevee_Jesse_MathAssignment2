using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class groundCollision : MonoBehaviour
{
    GameObject ground;

    GameObject[] vertices = new GameObject[4];
    GameObject nearest;
    public GameObject pointPrefab;
    public GameObject collisionCircle; //going to try using circle square collision on every object by being janky
    public Vector2 mtv;
    //how are we being janky?
    // by making a circle a child of the object, it should follow the object wherever it goes
    //thus we can resolve circle rect collisions like mad men.

    // Start is called before the first frame update
    void Start()
    {
        ground = GameObject.Find("grass");
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 rectPos = ground.transform.position;
        Vector2 extents = new Vector2(ground.transform.localScale.x, ground.transform.localScale.y) * 0.5f;
        Vector2 forward = ground.transform.right;
        Vector2 perpendicular = ground.transform.up;
        float radius = collisionCircle.transform.localScale.x * 0.5f;

        bool groundhit = circleSquareCollision(collisionCircle.transform.position, radius, rectPos, extents, out mtv);

        if (groundhit)
        {
            Debug.Log("Yikes");
            transform.position -= (Vector3)mtv;
        }



    }


    
    bool circleSquareCollision(Vector2 circle, float radius, Vector2 rect, Vector2 extents, out Vector2 mtv)
    {
        Vector2 nearest = new Vector2(
            Mathf.Clamp(circle.x, rect.x - extents.x, rect.x + extents.x),
            Mathf.Clamp(circle.y, rect.y - extents.y, rect.y + extents.y));

        Vector2 fromCircleToNearest = nearest - circle;

        bool isCollision = fromCircleToNearest.sqrMagnitude <= radius * radius;
        // Check for collision
        if (isCollision)
        {
            float distance = fromCircleToNearest.magnitude;
            mtv = fromCircleToNearest.normalized * (radius - distance);
        }
        else
        {
            mtv = Vector2.zero;
        }
        return isCollision;
    }
}
