using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOCollsion : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Destroy")
        {
            Debug.Log("collided");
            Destroy(gameObject);
        }
    }
}
