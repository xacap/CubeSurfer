using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;
    private float hInput;
    private Rigidbody _rb;
    public bool run;
    public float rotateSpeed = 75f;
    float rayDistanceDown = 10f;
    public Vector3 platformPosition = new Vector3(0,0,0);

   
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        run = false;
    }

    void FixedUpdate()
    {
        if (run)
        {
            Vector3 forwardRun = this.transform.position + this.transform.forward * moveSpeed * Time.fixedDeltaTime;
            _rb.transform.position = forwardRun;

            hInput = Input.GetAxis("Horizontal") * moveSpeed;

            if (hInput != 0)
            {
                Vector3 v3MovTow;

                v3MovTow = Vector3.MoveTowards(this.transform.position, platformPosition, 0.0f);


                Vector3 leftOut = new Vector3(-2, this.transform.position.y, this.transform.position.z);
                Vector3 rightOut = new Vector3(2, this.transform.position.y, this.transform.position.z);

                        Vector3 runPos = this.transform.position + this.transform.right * hInput * Time.fixedDeltaTime;
                        Vector3 rP = runPos - platformPosition;

                        if (rP.x < leftOut.x)
                        {
                            runPos.x = leftOut.x;
                        }
                        if (rP.x > rightOut.x)
                        {
                            runPos.x = rightOut.x;
                        }

                      //  Debug.Log("v3MovTow" + v3MovTow + " runPos = " + runPos + " rP = " + rP);
                        Debug.Log(platformPosition);


                        _rb.transform.position = runPos;
            }
            Debug.Log(platformPosition);

        }

        /* void FixedUpdate()
         {
             RaycastHit hitDown;
             GameObject targetPlatform;
             Vector3 v3MovTow;

                 if (run)
                 {
                      Vector3 forwardRun = this.transform.position + this.transform.forward * moveSpeed * Time.fixedDeltaTime;
                      _rb.transform.position = forwardRun;

                      hInput = Input.GetAxis("Horizontal") * moveSpeed;


                 if (hInput != 0)
                 {
                     if (Physics.Raycast(this.transform.position, this.transform.forward, out hitDown, rayDistanceDown))
                     {
                         if (hitDown.collider.gameObject.CompareTag("platform"))
                         {
                             targetPlatform = hitDown.transform.gameObject;
                             v3MovTow = Vector3.MoveTowards(this.transform.position, targetPlatform.transform.position, 0.0f);


                             Vector3 leftOut = new Vector3(-2, this.transform.position.y, this.transform.position.z);
                             Vector3 rightOut = new Vector3(2, this.transform.position.y, this.transform.position.z);

                             Vector3 runPos = this.transform.position + this.transform.right * hInput * Time.fixedDeltaTime;
                             Vector3 rP = runPos - targetPlatform.transform.position;

                             if (runPos.x < leftOut.x)
                             {
                                 runPos.x = leftOut.x;
                             }
                             if (runPos.x > rightOut.x)
                             {
                                 runPos.x = rightOut.x;
                             }

                             Debug.Log("v3MovTow" + v3MovTow + "runPos = " + runPos + "rP = " + rP);

                             _rb.transform.position = runPos;
                         }
                     }
                 }


             }

         }
        */



    }
    public void Turn(float angle)
    {
        _rb.transform.rotation = Quaternion.Slerp(_rb.transform.rotation,

            Quaternion.Euler(0, angle, 0), rotateSpeed);

    }
}
