using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableWall : MonoBehaviour
{
    public float timeSinceRelease = 5;
    public FixedJoint2D joint;

    private void Update()
    {
        if(timeSinceRelease > 0)
        {
            timeSinceRelease -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.O))
        {
            if (joint != null)
            {
                Destroy(joint);
            }
            timeSinceRelease = 5;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag.Equals("Player") && timeSinceRelease <= 0)
        {
            if(joint == null)
            {
                joint = gameObject.AddComponent<FixedJoint2D>();
                joint.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
                joint.anchor = collision.GetContact(0).point;
                joint.connectedAnchor = collision.GetContact(0).point;
            }
        }
    }
}
