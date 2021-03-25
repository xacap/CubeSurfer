using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;
    private float vInput;
    private float hInput;
    private Rigidbody _rb;
    public bool run;


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
            
            Vector3 leftOut = new Vector3(-2, this.transform.position.y, this.transform.position.z);
            Vector3 rightOut = new Vector3(2, this.transform.position.y, this.transform.position.z);

            Vector3 runPos = this.transform.position + this.transform.right * hInput * Time.fixedDeltaTime;
            
            if (runPos.x < leftOut.x)
            {
                runPos.x = leftOut.x;
            }
            if (runPos.x > rightOut.x)
            {
                runPos.x = rightOut.x;
            }
            _rb.transform.position = runPos;

        }
        }

    }
   
   
    
}
