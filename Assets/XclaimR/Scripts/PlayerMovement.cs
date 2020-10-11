using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float moveSpeed;
    [SerializeField] float jumpHeight = 10f;
    //[SerializeField] float jumpSpeed = 5f;

    [SerializeField]public bool isGrounded = false;


    Vector3 vector;

    Rigidbody2D body;
    GameObject gameManager;
    GlobalVariables globalV;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager");
        globalV = gameManager.GetComponent<GlobalVariables>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        moveSpeed = globalV.playerSpeed;
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

    void OnCollisionExit2D(Collision2D collision)
    {
        //Physics.IgnoreLayerCollision(8, 12, (.velocity.y > 0.0f));
        if (collision.gameObject.tag == "Ground" && !Input.GetKeyDown(KeyCode.W))
        {
            isGrounded = false;
        }
    }


}
