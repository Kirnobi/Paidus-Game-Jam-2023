using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovingPlatform : MonoBehaviour
{
    public float moveSpeed;
    public float oscillationDistance;
    public float movedDistance = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(moveSpeed*Time.deltaTime, 0, 0);
        movedDistance += moveSpeed * Time.deltaTime;
        if(Mathf.Abs(movedDistance) > oscillationDistance)
        {
            movedDistance = 0;
            moveSpeed = -moveSpeed;
        }
    }
}
