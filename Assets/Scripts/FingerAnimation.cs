using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerAnimation : MonoBehaviour
{

   
    void FixedUpdate()
    {

        transform.localPosition = new Vector3(Mathf.PingPong(Time.time * 200, 200), transform.localPosition.y, transform.localPosition.z);

    }


}
