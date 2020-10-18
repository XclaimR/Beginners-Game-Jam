using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOFlight : MonoBehaviour
{
    GameObject[] startPoints;
    public GameObject UFO;
    int index;
    bool isActive = false;
    float speed;
    Vector3 vector;
    GameObject ufoTemp;

    // Start is called before the first frame update
    void Start()
    {
        startPoints = GameObject.FindGameObjectsWithTag("StartPoint");
    }

    // Update is called once per frame
    void Update()
    {
        StartFlight();
    }

    void StartFlight()
    {
        if (!ufoTemp)
        {
            index = Random.Range(0, startPoints.Length);
            ufoTemp = Instantiate(UFO, startPoints[index].transform.position, Quaternion.identity);
            ufoTemp.transform.Rotate(0f, 0f, -29.375f);
            speed = Random.Range(4f, 8f);
        }

        if (ufoTemp)
        {
            isActive = true;
            ufoTemp.transform.position += new Vector3(speed,0f,0f) * Time.deltaTime;
        }
    }
}
