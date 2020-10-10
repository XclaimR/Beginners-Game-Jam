using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHMovement : MonoBehaviour
{
    public GameObject player;

    private float x_scale;
    private float y_scale;
    Vector3 vector;

    // Start is called before the first frame update
    void Start()
    {
        x_scale = transform.localScale.x;
        y_scale = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(player.transform.position.x,player.transform.position.y - transform.position.y/5);
        vector.x = Input.GetAxis("Horizontal");
        if (vector.x < 0)
        {
            transform.localScale = new Vector2(-x_scale, y_scale);
        }
        if (vector.x > 0)
        {
            transform.localScale = new Vector2(x_scale, y_scale);
        }
    }
}
