using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectiblesText : MonoBehaviour
{
    public Text collectText;
    GameObject gameManager;
    GlobalVariables globalV;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        globalV = gameManager.GetComponent<GlobalVariables>();
    }

    // Update is called once per frame
    void Update()
    {
        collectText.text = globalV.collected.ToString() + " / "+ globalV.totalCollectibles.ToString();
    }
}
