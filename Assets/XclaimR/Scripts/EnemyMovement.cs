using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]float speed = 2f ;
    [SerializeField]public float waitTime = 2f;
    [SerializeField]public bool MoveRight = true;
    [SerializeField] public bool isPause = false;

    private float x_scale;
    private float y_scale;

    // Use this for initialization
    void Start()
    {
        x_scale = transform.localScale.x;
        y_scale = transform.localScale.y;
    }

    void Update()
    {
        // Use this for initialization
        if (MoveRight && !isPause)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(x_scale, y_scale);
        }
        else if(!MoveRight && !isPause)
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-x_scale, y_scale);
        }
    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        
        if (trig.gameObject.CompareTag("Turn") && gameObject.CompareTag("Enemy"))
        {
            isPause = true;
            Invoke("Resume", waitTime);
            if (MoveRight)
            {
                MoveRight = false;
            }
            else
            {
                MoveRight = true;
            }
        }
    }

    void Resume()
    {
        isPause = false;
    }
}
