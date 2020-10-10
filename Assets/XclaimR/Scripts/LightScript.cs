using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public GameObject fl_point;
    public EnemyMovement eMove;
    bool isTurn = true;

    // Start is called before the first frame update

    void Update()
    {
        if (!eMove.MoveRight && isTurn && !eMove.isPause)
        {
            transform.Rotate(180,0 , 0);
            isTurn = false;
        }
        if (eMove.MoveRight && !isTurn && !eMove.isPause)
        {
            transform.Rotate(180, 0, 0);
            isTurn = true;
        }
        transform.position = fl_point.transform.position;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            //Destroy(collider.gameObject);
            Debug.Log("Detected");
        }
    }

    void Turn()
    {
        isTurn = !isTurn;
    }
}
