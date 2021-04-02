using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;
    private float hInput;
    public int swipeDirect = 0;
    private Rigidbody _rb;
    public bool run;
    public Vector3 platformPosition = Vector3.zero;

    public float lerpTime = 30f;
    public float currentLerpTime = 0;
    private Quaternion _targetRotation = Quaternion.identity;
    public bool forwardXorZ = true;


    private void Awake()
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

            hInput = swipeDirect * moveSpeed;
            //hInput = Input.GetAxis("Horizontal") * moveSpeed;
            Debug.Log("swipeDirect  " + swipeDirect);

            if (hInput != 0)
            {
                Vector3 v3MovTow;
                Vector3 runPos = this.transform.position + this.transform.right * hInput * Time.fixedDeltaTime;

                v3MovTow = Vector3.MoveTowards(runPos, platformPosition, 0.0f);

                Vector3 leftOutX = new Vector3(platformPosition.x - 2, this.transform.position.y, this.transform.position.z);
                Vector3 rightOutX = new Vector3(platformPosition.x + 2, this.transform.position.y, this.transform.position.z);

                Vector3 leftOutZ = new Vector3(this.transform.position.x, this.transform.position.y, platformPosition.z - 2);
                Vector3 rightOutZ = new Vector3(this.transform.position.x, this.transform.position.y, platformPosition.z + 2);

                if (forwardXorZ)
                {
                    if (v3MovTow.x <= leftOutX.x)
                    {
                        runPos.x = leftOutX.x;
                    }
                    if (v3MovTow.x >= rightOutX.x)
                    {
                        runPos.x = rightOutX.x;
                    }
                }
                else 
                {
                    if (v3MovTow.z <= leftOutZ.z)
                    {
                        runPos.z = leftOutZ.z;
                    }
                    if (v3MovTow.z >= rightOutZ.z)
                    {
                        runPos.z = rightOutZ.z;
                    }
                }

                _rb.transform.position = runPos;
            }
        }
    }

    private void Update()
    {
        currentLerpTime += Time.deltaTime;
        _rb.transform.rotation = Quaternion.LerpUnclamped(_rb.transform.rotation, _targetRotation, currentLerpTime / lerpTime);
        
    }
    public void SetBlendedEulerAngles(Vector3 angles)
    {
        _targetRotation = Quaternion.Euler(angles);
        run = true;
    }
}
