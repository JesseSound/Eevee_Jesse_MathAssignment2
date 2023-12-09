using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impulseForce : MonoBehaviour
{

    bool isClickedOn()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float dist = Vector2.Distance(mousePosition, gameObject.transform.position);
        if (Input.GetMouseButtonDown(0) && dist <= 0.5f)
        {
            Debug.Log("Youch!");
        }
        return dist <= 0.5;
    }
}
