using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Character : MonoBehaviour
{
	[SerializeField] private Rigidbody2D _theRb;

	public Animator anim;

	[SerializeField] private Transform _checkGround;

	[SerializeField] private LayerMask _maskGround;

	[SerializeField] private float _jumpForce;

	private bool _isGround;
	
	private GameController gameControl => GameController.instance;

	public void Jump()
	{
		_theRb.velocity = new Vector3(0, _jumpForce);
	}

	private void Update()
	{
		if(gameControl.isStop) return;
		_isGround = Physics2D.OverlapCircle(_checkGround.transform.position, 0.1f, _maskGround);
		if(Input.GetKey(KeyCode.Space))
		{
			Jump();
		}
		anim.SetBool("isGround", _isGround);
		anim.SetBool("isFall", _theRb.velocity.y < -0.1f);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireSphere(_checkGround.transform.position, 0.1f);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Trap"))
		{
			gameControl.LoseGame();
			_theRb.velocity = new Vector2(-15, Random.Range(5, 15));
			anim.SetTrigger("isDie");
		}
	}
}
