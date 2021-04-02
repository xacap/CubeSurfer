using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTriggerRight : MonoBehaviour
{
    public GameObject thisPlatform;
    private PlayerBehavior playerBehavior;

    private void Awake()
    {
        playerBehavior = GameObject.Find("GenerateStack").GetComponent<PlayerBehavior>();
    }

    void OnTriggerEnter(Collider other)
    {
        playerBehavior.forwardXorZ = true;
        playerBehavior.SetBlendedEulerAngles(Vector3.zero);
        playerBehavior.platformPosition = thisPlatform.transform.position;
    }
}
