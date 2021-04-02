using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        LevelGenerator.instance.AddPiece();
        LevelGenerator.instance.RemoveOldestPiece();
    }
}
