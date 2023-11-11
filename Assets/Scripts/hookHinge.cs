using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookHinge : MonoBehaviour
{
    HingeJoint2D joint;

    // Update is called once per frame
    void Update()
    {
        joint = GetComponent<HingeJoint2D>();
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(joint != null)
            {
                Destroy(joint);
            }
            else
            {
                joint = gameObject.AddComponent<HingeJoint2D>();
            }
        }
    }
}
