using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPlayerState
{
    ePlayerActive,
    ePlayerWinner,
    ePlayerLost
}
public class PlayerInStackBehaviour : MonoBehaviour
{
    private EPlayerState mState = EPlayerState.ePlayerActive;
    float rayDistance = 0.5f;
    float rayDown = 1f;
    private GameBehavior _gameManager;

    private void Awake()
    {
      _gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }
    private void FixedUpdate()
    {
        Ray cubeRay = new Ray(this.transform.position, Vector3.forward);
        Debug.DrawRay(this.transform.position, Vector3.forward * rayDistance);

        Ray cubeRay1 = new Ray(this.transform.position, Vector3.down);
        Debug.DrawRay(this.transform.position, Vector3.down * rayDown);

        RaycastHit hit;
        Vector3 forvard = Vector3.forward;
        Vector3 left = - Vector3.right;
        Vector3 right = Vector3.right;
        Vector3 direction = Vector3.zero;

        if(this.transform.rotation.y == 0)
        {
            direction = forvard;
        }
        else if (this.transform.rotation.y < 0)
        {
            direction = left;
        }
        else if (this.transform.rotation.y > 0)
        {
            direction = right;
        }

        if (Physics.Raycast(this.transform.position, direction, out hit, rayDistance))
        {
            if (hit.collider.gameObject.CompareTag("CubeWall"))
            {
                mState = EPlayerState.ePlayerLost;
                _gameManager.GameFinish();
            }
            if (hit.collider.gameObject.CompareTag("FinishTrigger"))
            {
                mState = EPlayerState.ePlayerWinner;
                _gameManager.LevelPassed();
            }
        }
        else if (Physics.Raycast(this.transform.position, Vector3.down, out hit, rayDown))
        {
            if (hit.collider.gameObject.CompareTag("platform"))
            {
                mState = EPlayerState.ePlayerLost;
                _gameManager.GameFinish();
            }
        }
    }
    public EPlayerState GetState()
    {
        return mState;
    }
}
