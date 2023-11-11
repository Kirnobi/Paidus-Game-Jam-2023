using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Rigidbody2D hook;
    public GameObject[] prefabRopeSegs;
    public int numLinks = 5;
    public GameObject birdPrefab;
    public GameObject tail;

    // Start is called before the first frame update
    void Start()
    {
        generateRope();
    }

    void generateRope()
    {
        int RopeLayer = LayerMask.NameToLayer("RopeLayer");
        Rigidbody2D prevBody = hook;
        for(int i = 0; i < numLinks; i++)
        {
            int index = UnityEngine.Random.Range(0, prefabRopeSegs.Length);
            GameObject newSeg = Instantiate(prefabRopeSegs[index]);
            newSeg.layer = RopeLayer;
            newSeg.transform.parent = transform;
            newSeg.transform.position = transform.position;
            HingeJoint2D hj = newSeg.GetComponent<HingeJoint2D>();
            hj.connectedBody = prevBody;

            prevBody = newSeg.GetComponent<Rigidbody2D>();
            tail = prevBody.gameObject;
        }
        GameObject bird = Instantiate(birdPrefab);
        bird.layer = RopeLayer;
        bird.transform.parent = transform;
        bird.transform.position = transform.position;
        bird.tag = "Player";
        HingeJoint2D birdHinge = bird.GetComponent<HingeJoint2D>();
        birdHinge.connectedBody = prevBody;
    }
}
