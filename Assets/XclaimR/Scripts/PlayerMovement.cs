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

    public Animator animator;

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
        animator.SetFloat("isMove", Mathf.Abs(vector.x));
        transform.position += vector;

        if (Input.GetButton("Jump") && isGrounded && body.velocity.y == 0)
        {
            //Debug.Log("Jump");
            animator.SetTrigger("isJump");
            //animator.SetBool("Jump", true);
            isGrounded = false;
            Jump();
        }

        if(transform.position.y < -10f)
        {
            gameManager.GetComponent<Lives>().RemoveLives();
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
            animator.ResetTrigger("isJump");
            //animator.SetBool("Jump", false);
            isGrounded = true;
        }

        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "UFO")
        {
            if (globalV.collected == globalV.totalCollectibles)
            {
                Debug.Log("Entered");
                GameObject timer = GameObject.Find("Timer");
                float sTime = Time.time - timer.GetComponent<Timer>().startTime;
                string uname = PlayerPrefs.GetString("Username");
                gameManager.GetComponent<ScoreboardConnection>().AddScoreboard(uname,(int)sTime*1000);
                Debug.Log("Finish Time : "+timer.GetComponent<Timer>().DisplayTime(sTime));

                //gameManager.GetComponent<SceneLoader>().LoadNextScene();
                gameManager.GetComponent<SceneLoader>().LoadGameOverScene();
            }
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
