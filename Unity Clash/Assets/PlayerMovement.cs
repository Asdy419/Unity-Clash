using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D reference;
    public float MovementSpeed = 1;
    private Rigidbody2D _rigidbody;
    public float JumpForce = 1;
    public float jumps = 0;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask WhatIsGround;

    public int extraJumps;
    public int extraJumpsValue;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("lazystage"))
        {
            jumps = 0;
            Debug.Log("something happening");

        }
    }


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpsValue;


    }
    float maxSpeed = 1.0f; // units/sec
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WhatIsGround);
    }

    private void Update()

    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            _rigidbody.velocity = Vector2.up * JumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            _rigidbody.velocity = Vector2.up * JumpForce;
        }

        float numval = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            numval = -1;

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            numval = 1;

        }

        transform.position += new Vector3(numval, 0, 0) * Time.deltaTime * MovementSpeed;

    }
}

