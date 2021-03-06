﻿using System.Collections;
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

    private AudioSource transformSound;
    // Start is called before the first frame update
    void Start()
    {
        x_scale = alien.transform.localScale.x;
        y_scale = alien.transform.localScale.y;
        vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        transformSound = GameObject.Find("transformSound").GetComponent<AudioSource>();
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
            transformSound.Play();
            alien.transform.GetChild(0).gameObject.SetActive(false);
            alien.transform.GetChild(1).gameObject.SetActive(false);
            alien.GetComponent<BoxCollider2D>().enabled = false;
            alien.GetComponent<Rigidbody2D>().gravityScale = 0;
            alien.GetComponent<PlayerMovement>().enabled = false;
            alien.GetComponent<PlayerMovement>().playerWalk.Stop();
            /*if (!deathVFX) { return; }

            GameObject deathVFXObject = Instantiate(deathVFX, transform.position, Quaternion.identity);

            Destroy(deathVFXObject, 1f);*/
            //human.GetComponent<SpriteRenderer>().enabled = true;
            human.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.W) && pm.isGrounded)
        {
            //vcam.Follow = alien.transform;
            transformSound.Play();
            alien.transform.GetChild(0).gameObject.SetActive(true);
            alien.transform.GetChild(1).gameObject.SetActive(true);
            alien.GetComponent<BoxCollider2D>().enabled = true;
            alien.GetComponent<Rigidbody2D>().gravityScale = 2;
            alien.GetComponent<PlayerMovement>().enabled = true;
            //human.GetComponent<SpriteRenderer>().enabled = false;
            human.SetActive(false);
        }
    }
}
