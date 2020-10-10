using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransform : MonoBehaviour
{
    public GameObject alien;
    public GameObject human;


    public PlayerMovement pm;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.W) && pm.isGrounded)
        {
            alien.SetActive(false);
            human.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.W) && pm.isGrounded)
        {
            alien.SetActive(true);
            human.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
