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

    void Start()
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

        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, rayDistance))
        {
            if (hit.collider.gameObject.CompareTag("CubeWall"))
            {
                Debug.Log("попал в стенку");
                mState = EPlayerState.ePlayerLost;
                _gameManager.GameFinish();
            }
            if (hit.collider.gameObject.CompareTag("FinishTrigger"))
            {
                Debug.Log("попал в финиш");
                mState = EPlayerState.ePlayerWinner;
                _gameManager.LevelPassed();


            }
            else if (hit.collider.gameObject.CompareTag("TriggerLeft"))
            {

                PlayerBehavior _go = GameObject.Find("GenerateStack").GetComponent<PlayerBehavior>();
                _go.Turn(-90);
            }
            else if (hit.collider.gameObject.CompareTag("TriggerRight"))
            {

                PlayerBehavior _go = GameObject.Find("GenerateStack").GetComponent<PlayerBehavior>();
                _go.Turn(0);
            }


        }
        else if (Physics.Raycast(this.transform.position, Vector3.down, out hit, rayDown))
        {
            if (hit.collider.gameObject.CompareTag("platform"))
            {
                Debug.Log("упал на пол");
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
