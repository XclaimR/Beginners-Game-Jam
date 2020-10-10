using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpHeight = 10f;
    //[SerializeField] float jumpSpeed = 5f;

    [SerializeField]public bool isGrounded = false;


    Vector3 vector;

    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        vector.x = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        transform.position += vector;

        if (Input.GetButton("Jump") && isGrounded && body.velocity.y == 0)
        {
            //Debug.Log("Jump");
            isGrounded = false;
            Jump();
        }
    }

    private void Jump()
    {
        body.AddForce(new Vector2(0,jumpHeight), ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Physics.IgnoreLayerCollision(8, 12, (.velocity.y > 0.0f));
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        
    }
}
