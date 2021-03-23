using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0f, 1.2f, -2.6f);
    private Transform target;

    void LateUpdate()
    {
        target = GameObject.Find("Player(Clone)").transform;

        this.transform.position = target.TransformPoint(camOffset);

        this.transform.LookAt(target);
    }
}
