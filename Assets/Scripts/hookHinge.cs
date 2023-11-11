using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookHinge : MonoBehaviour
{
    HingeJoint2D joint;
    bool canStick = false;

    // Update is called once per frame
    void Update()
    {
        joint = GetComponent<HingeJoint2D>();
        // (canStick)
        //
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (joint != null)
                {
                    Destroy(joint);
                }
                else
                {
                    joint = gameObject.AddComponent<HingeJoint2D>();
                }
            }
        //
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
