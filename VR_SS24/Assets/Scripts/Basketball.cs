using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class Basketball : MonoBehaviour
{
    GameManager gameManager;
    UIManager uIManager;
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        // show return to ship panel if in final task
        if (other.gameObject.CompareTag("Basket") && gameManager.InTaskFour)
        {
            uIManager.ShowReturnPanel();
        }
    }
}
