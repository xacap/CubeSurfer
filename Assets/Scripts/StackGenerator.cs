using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackGenerator : MonoBehaviour
{
    public static StackGenerator instance;

    public GameObject cube;
    public GameObject player;
    public List<GameObject> stack = new List<GameObject>();

    void Awake()
    { if (instance == null) { instance = this; } }

    void Start()
    {
        GenerateStack();
    }
    public void GenerateStack()
    {
        for (int i = 0; i < 4; i++)
        {
            AddCube();
        }
    }
   public void StackUpDown(int a)
    {
        if (stack.Count != 0) 
        { 
            for (int i = 0; i < stack.Count; i++)
            {
                GameObject _go = stack[i];
                Vector3 _v3 = _go.transform.position;
                _v3.y += a;
                stack[i].transform.position = _v3;
            }
        }
        if (a == -1)
        {
            Vector3 _v31 = this.transform.position;
            _v31.y += 1;
            this.transform.position = _v31;
        }
    }
    public void IsKinematicOnOff()
    {
        bool kinematic = this.GetComponent<Rigidbody>().isKinematic;

        if (kinematic)
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
        }
        else { 
            this.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("CubeWall"))
        {
            bool kinematic = this.GetComponent<Rigidbody>().isKinematic;
            if (kinematic) 
            { 
            IsKinematicOnOff();
            }
            this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * 5000);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CubeCollect"))
        {
            AddCube();
        }
        else if (collision.gameObject.CompareTag("platform"))
        {
            IsKinematicOnOff();
            Vector3 pos = this.transform.position;
            pos.y = 0.0f;
            this.transform.position = pos;
        }
    }
    public void AddCube()
    {
        if (stack.Count == 0)
        {
            GameObject playerInStack = GameObject.Instantiate(player) as GameObject;
            playerInStack.transform.SetParent(this.transform);
            playerInStack.transform.position = new Vector3(this.transform.position.x, 1.5f, this.transform.position.z);
            stack.Add(playerInStack);

            Vector3 playerSize = playerInStack.GetComponent<BoxCollider>().size;
            Vector3 playerSizePos = playerInStack.transform.position;
            ReSizeCollider(playerSize, playerSizePos);
        }
        else
        {
            StackUpDown(1);
            GameObject cubeInStack = GameObject.Instantiate(cube) as GameObject;
            cubeInStack.transform.SetParent(this.transform);
            cubeInStack.transform.position = new Vector3(this.transform.position.x, 1, this.transform.position.z);
            stack.Add(cubeInStack);

            Vector3 cubeSize = cubeInStack.GetComponent<BoxCollider>().size;
            Vector3 cubeSizePos = cubeInStack.transform.position;
            cubeSizePos.y = cubeInStack.transform.position.y / 2;
            ReSizeCollider(cubeSize, cubeSizePos);
        }
    }
    void ReSizeCollider(Vector3 objSize, Vector3 objPos)
    {
        Vector3 thisSize = this.GetComponent<BoxCollider>().size;
        Vector3 thisCenter = this.GetComponent<BoxCollider>().center;

        thisSize.y += objSize.y;
        thisCenter.y += objPos.y ;

        this.GetComponent<BoxCollider>().size = thisSize;
        this.GetComponent<BoxCollider>().center = thisCenter;
    }
   
    public void RemoveCube()
    {
        GameObject _go = stack[stack.Count - 1];
        _go.transform.parent = null;
        Vector3 cubeSize = _go.GetComponent<BoxCollider>().size;
        stack.RemoveAt(stack.Count - 1);
        StackUpDown(-1);
        ReSizeCollider(-cubeSize, -cubeSize /2);
        Destroy(_go, 5);
    }

    float rayDistance = 0.7f;
    void FixedUpdate()
    {
        List<GameObject> tmpArray = stack;
        int cubeCoub= 0;

        foreach (GameObject _go in tmpArray)
        {
            Ray cubeRay = new Ray(_go.transform.position, _go.transform.forward);
            Debug.DrawRay(_go.transform.position, _go.transform.forward * rayDistance);
            RaycastHit hit;

            if (Physics.Raycast(_go.transform.position, _go.transform.forward, out hit, rayDistance))
            {
                if (hit.collider.gameObject.CompareTag("CubeWall"))
                {
                    _go.GetComponent<Rigidbody>().isKinematic = false;
                    cubeCoub += 1;
                }
            }
        }
        for (int i = 0; i < cubeCoub; i++)
        {
            RemoveCube();
        }
    }
}
