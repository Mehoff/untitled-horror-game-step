using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HorrorGame;


public class Player : MonoBehaviour
{
    private MovementDirection direction;
    private Rigidbody2D rb;
    private Animator anim;

    public GameObject closestInteractable;
    public float movePower = 10f;
    public float KickBoardMovePower = 15f;
    public float jumpPower = 20f; //Set Gravity Scale in Rigidbody2D Component to 5


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 moveVelocity = Vector3.zero;
        anim.SetBool("isRun", false);


        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            direction = MovementDirection.LEFT;
            moveVelocity = Vector3.left;

            transform.localScale = new Vector3((float)direction, 1, 1);
            if (!anim.GetBool("isJump"))
                anim.SetBool("isRun", true);

        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            direction = MovementDirection.RIGHT;
            moveVelocity = Vector3.right;

            transform.localScale = new Vector3((float)direction, 1, 1);
            if (!anim.GetBool("isJump"))
                anim.SetBool("isRun", true);

        }

        if (Input.GetButton("Submit"))
        {
            Debug.Log("Click Submit");
        }
        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("CollisionEnter: " + other.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TriggerEnter: " + other.gameObject.name);
        closestInteractable = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("TriggerExit: " + other.gameObject.name);
        closestInteractable = null;
    }
}
