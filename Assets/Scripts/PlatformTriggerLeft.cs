using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTriggerLeft : MonoBehaviour
{
    public GameObject thisPlatform;
    private PlayerBehavior playerBehavior;

    private void Awake()
    {
        playerBehavior = GameObject.Find("GenerateStack").GetComponent<PlayerBehavior>();
    }

    void OnTriggerEnter(Collider other)
    {
        playerBehavior.forwardXorZ = false;
        playerBehavior.SetBlendedEulerAngles(Vector3.up * - 90);
        playerBehavior.platformPosition = thisPlatform.transform.position;
    }
}
