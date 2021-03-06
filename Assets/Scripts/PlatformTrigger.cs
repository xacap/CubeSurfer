using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public GameObject thisPlatform;
    private PlayerBehavior playerBehavior;

    private void Awake()
    {
        playerBehavior = GameObject.Find("GenerateStack").GetComponent<PlayerBehavior>();

    }
   
    void OnTriggerEnter(Collider other)
    {
        playerBehavior.platformPosition = thisPlatform.transform.position;
    }
}
