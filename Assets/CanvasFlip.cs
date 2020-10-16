using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFlip : MonoBehaviour
{
    GameObject player;
    Vector3 vector;
    bool isRight = true;

    void Start()
    {
        player = GameObject.Find("Orb");
    }

    void Update()
    {
        if (player)
        {
            vector.x = Input.GetAxis("Horizontal");
            if (vector.x < 0 && isRight)
            {
                Flip();
            }
            if (vector.x > 0 && !isRight)
            {
                Flip();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Flip()
    {
        isRight = !isRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
