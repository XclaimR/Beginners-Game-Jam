using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    float moveSpeed;
    [SerializeField] float jumpHeight = 10f;
    //[SerializeField] float jumpSpeed = 5f;

    [SerializeField]public bool isGrounded = false;
    public bool isPlaying = false;

    Vector3 vector;

    Rigidbody2D body;
    GameObject gameManager;
    GlobalVariables globalV;

    public AudioSource playerWalk;
    private AudioSource playerJump;
    private AudioSource playerLand;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager");
        globalV = gameManager.GetComponent<GlobalVariables>();
        if(SceneManager.GetActiveScene().name == "Planet 1")
        {
            playerWalk = GameObject.Find("SnowFS").GetComponent<AudioSource>();
        }
        if(SceneManager.GetActiveScene().name == "Planet 2")
        {
            playerWalk = GameObject.Find("MetalFS").GetComponent<AudioSource>();
        }
        if (SceneManager.GetActiveScene().name == "Planet 3")
        {
            //CHANGE ONCE FOOTSTEPS ARE MADE
            playerWalk = GameObject.Find("MetalFS").GetComponent<AudioSource>();
        }

        playerJump = GameObject.Find("JumpSound").GetComponent<AudioSource>();
        playerLand = GameObject.Find("LandSound").GetComponent<AudioSource>();
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
        //Debug.Log(Input.GetAxis("Horizontal"));
        if (!isPlaying && vector.x != 0 && body.velocity.y == 0)
        {
            //Debug.Log("Entered");
            isPlaying = true;
            playerWalk.Play();
        }
        else if(isPlaying && vector.x == 0)
        {
            playerWalk.Stop();
            isPlaying = false;
        }
            

        if (Input.GetButton("Jump") && isGrounded && body.velocity.y == 0)
        {
            playerWalk.Stop();
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
        playerJump.Play();
        body.AddForce(new Vector2(0,jumpHeight), ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Physics.IgnoreLayerCollision(8, 12, (.velocity.y > 0.0f));
        if (collision.gameObject.tag == "Ground")
        {
            playerLand.Play();
            isPlaying = false;
            animator.ResetTrigger("isJump");
            //animator.SetBool("Jump", false);
            isGrounded = true;
        }

        if(collision.gameObject.tag == "Enemy")
        {
            gameManager.GetComponent<Lives>().RemoveLives();
        }
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "UFO")
        {
            if (globalV.collected == globalV.totalCollectibles)
            {
                Debug.Log("Entered");
                //gameManager.GetComponent<SceneLoader>().LoadNextScene();
                //gameManager.GetComponent<SceneLoader>().LoadGameOverScene();
                if (SceneManager.GetActiveScene().buildIndex + 1 != 7)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    GameObject timer = GameObject.Find("Timer");
                    float sTime = Time.time - timer.GetComponent<Timer>().startTime;
                    PlayerPrefs.SetFloat("Runtime", sTime);
                    string uname = PlayerPrefs.GetString("Username");
                    gameManager.GetComponent<ScoreboardConnection>().AddScoreboard(uname, (int)sTime * 1000);
                    Debug.Log("Finish Time : " + timer.GetComponent<Timer>().DisplayTime(sTime));
                    SceneManager.LoadScene("Victory");
                }
                    
            }
        }

        if(collider.gameObject.tag == "Enemy")
        {
            gameManager.GetComponent<Lives>().RemoveLives();
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
