using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    GameBehavior _gameManager;

    public void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "GenerateStack")
        { 
            Destroy(this.transform.parent.gameObject);
            _gameManager.Items += 1;
        }
    }
}
