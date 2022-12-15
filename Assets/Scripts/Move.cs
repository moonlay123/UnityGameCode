using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 5f;
    Vector3 input;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Mover();
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            Jump();
        }
        CheckingGround();
    }
    private void Mover()
    {
        {
            input = new Vector3(Input.GetAxis("Horizontal"), 0);
            transform.position += input * speed * Time.deltaTime;
        }
    }

    private void Jump()
    {
        //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        rb.AddForce(Vector2.up * jumpForce);
    }
    private bool onGround;
    public Transform GroundCheck;
    public float CheckRadius = 0.5f;
    public LayerMask Ground;
    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, Ground);
    }
}
