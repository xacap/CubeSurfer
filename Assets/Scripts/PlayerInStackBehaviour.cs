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
    float rayDistance = 0.7f;
    float rayDown = 1f;
    private GameBehavior _gameManager;
    private Vector3 rayPositionY = new Vector3(0, -0.5f, 0);


    private void Awake()
    {
      _gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();

    }
    private void FixedUpdate()
    {
        Ray cubeRay = new Ray(this.transform.position + rayPositionY, Vector3.forward);
        Debug.DrawRay(this.transform.position + rayPositionY, Vector3.forward * rayDistance);

        Ray cubeRay1 = new Ray(this.transform.position, Vector3.down);
        Debug.DrawRay(this.transform.position, Vector3.down * rayDown);

        RaycastHit hit;
        
        if (Physics.Raycast(this.transform.position + rayPositionY, Vector3.forward, out hit, rayDistance) 
            || Physics.Raycast(this.transform.position + rayPositionY, -Vector3.right, out hit, rayDistance)
            || Physics.Raycast(this.transform.position + rayPositionY, Vector3.right, out hit, rayDistance))
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
