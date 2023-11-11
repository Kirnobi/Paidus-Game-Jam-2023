using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSegment : MonoBehaviour
{
    [SerializeField]
    GameObject aboveObject;
    [SerializeField]
    GameObject belowObject;
    [SerializeField]
    float spriteBottom;
    [SerializeField]
    float thisBottom;
    // Start is called before the first frame update
    void Start()
    {
        aboveObject = GetComponent<HingeJoint2D>().connectedBody.gameObject;
        RopeSegment aboveSegment = aboveObject.GetComponent<RopeSegment>();
        if (aboveSegment != null)
        {
            aboveSegment.belowObject = gameObject;
            spriteBottom = aboveObject.GetComponent<BoxCollider2D>().bounds.size.y;
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, -1 * spriteBottom);
        }
        else
        {
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2 (0, 0);
        }
    }
}
