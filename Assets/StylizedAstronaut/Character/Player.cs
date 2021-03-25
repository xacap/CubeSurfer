using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	private Animator _animator;
	private PlayerBehavior _playerBehaviour;

	void Start () {
		_animator = gameObject.GetComponentInChildren<Animator>();
		_playerBehaviour = GameObject.Find("GenerateStack").GetComponent<PlayerBehavior>();
	}

	void Update ()
	{
		if (_playerBehaviour.run) 
		{
			_animator.SetInteger ("AnimationPar", 1);
		}  else 
		{
			_animator.SetInteger ("AnimationPar", 0);
		}
	}

	
}
