using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : MonoBehaviour
{
    private PlayerBehavior _playerBehaviour;

    private void Start()
    {
        _playerBehaviour = GameObject.Find("GenerateStack").GetComponent<PlayerBehavior>();

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _playerBehaviour.run = true;
            GameBehavior.instance.StartGame();
            Destroy(this.gameObject);

        }
    }
}
