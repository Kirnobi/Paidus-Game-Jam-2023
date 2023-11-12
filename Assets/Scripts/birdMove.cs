using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdMove : MonoBehaviour
{
    public float moveCDMax =1.5f;
    public float moveCD;
    public bool canMove;
    public int speed;

    public bool grounded;

    GameObject hook;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveCD >= 0)
        {
            moveCD -= Time.deltaTime;
        }
        else if(grounded)
        {
            canMove = true;
        }

        if(hook.GetComponent<HingeJoint2D>() != null)
        {
            canMove = true;
        }

        if(canMove)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
                canMove = false;
                moveCD = moveCDMax;
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                canMove = false;
                moveCD = moveCDMax;
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(Vector2.down * speed, ForceMode2D.Impulse);
                canMove = false;
                moveCD = moveCDMax;
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                canMove = false;
                moveCD = moveCDMax;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            grounded = false;
        }
    }

}
