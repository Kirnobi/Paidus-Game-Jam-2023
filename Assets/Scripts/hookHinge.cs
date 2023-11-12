using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookHinge : MonoBehaviour
{
    HingeJoint2D hingeJoint;
    bool canStick = false;
    public Transform checkpointSpawn;

    // Update is called once per frame
    void Update()
    {
        hingeJoint = GetComponent<HingeJoint2D>();

        if (hingeJoint != null && Input.GetKeyDown(KeyCode.P))
        {
            Destroy(hingeJoint);
        }
        if (Input.GetKeyDown(KeyCode.P) && canStick)
        {
               hingeJoint = gameObject.AddComponent<HingeJoint2D>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag.Equals("Wall"))
        {
            canStick = true;
        }
        if (collision.transform.tag.Equals("Checkpoint"))
        {
            checkpointSpawn = collision.transform;
        }
        if(collision.transform.tag.Equals("Deathbox"))
        {
            transform.position = checkpointSpawn.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Wall"))
        {
            canStick = false;
        }
    }
}
