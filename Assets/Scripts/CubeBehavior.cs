using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    public GameBehavior gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }
   
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "GenerateStack")
        {
            Destroy(this.gameObject);
        }
    }
}
