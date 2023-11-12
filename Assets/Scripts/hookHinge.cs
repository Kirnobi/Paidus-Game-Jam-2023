using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookHinge : MonoBehaviour
{
    HingeJoint2D hingeJoint;
    bool canStick = false;

    // Update is called once per frame
    void Update()
    {
        hingeJoint = GetComponent<HingeJoint2D>();

        if (Input.GetKeyDown(KeyCode.P) && canStick)
        {
            if (hingeJoint != null)
            {
                Destroy(hingeJoint);
            }
            else
            {
                hingeJoint = gameObject.AddComponent<HingeJoint2D>();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Wall"))
        {
            canStick = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Wall"))
        {
            canStick = false;
        }
    }
}
