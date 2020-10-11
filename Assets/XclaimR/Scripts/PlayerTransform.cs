using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerTransform : MonoBehaviour
{
    public GameObject alien;
    public GameObject human;

    private float x_scale;
    private float y_scale;
    Vector3 vector;
    public PlayerMovement pm;
    CinemachineVirtualCamera vcam;
    // Start is called before the first frame update
    void Start()
    {
        x_scale = alien.transform.localScale.x;
        y_scale = alien.transform.localScale.y;
        vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        vector.x = Input.GetAxis("Horizontal");
        if (vector.x < 0)
        {
            alien.transform.localScale = new Vector2(-x_scale, y_scale);
        }
        if (vector.x > 0)
        {
            alien.transform.localScale = new Vector2(x_scale, y_scale);
        }

        if (Input.GetKeyDown(KeyCode.W) && pm.isGrounded)
        {
            //vcam.Follow = human.transform;
            alien.GetComponent<SpriteRenderer>().enabled = false;
            alien.GetComponent<BoxCollider2D>().enabled = false;
            alien.GetComponent<Rigidbody2D>().gravityScale = 0;
            alien.GetComponent<PlayerMovement>().enabled = false;
            human.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.W) && pm.isGrounded)
        {
            //vcam.Follow = alien.transform;
            alien.GetComponent<SpriteRenderer>().enabled = true;
            alien.GetComponent<BoxCollider2D>().enabled = true;
            alien.GetComponent<Rigidbody2D>().gravityScale = 2;
            alien.GetComponent<PlayerMovement>().enabled = true;
            human.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
