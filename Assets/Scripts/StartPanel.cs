using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : MonoBehaviour
{
    private PlayerBehavior _playerManager;

    private void Start()
    {
        _playerManager = GameObject.Find("GenerateStack").GetComponent<PlayerBehavior>();

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _playerManager.run = true;
            GameBehavior.instance.StartGame();
            Destroy(this.gameObject);

        }
    }
}
