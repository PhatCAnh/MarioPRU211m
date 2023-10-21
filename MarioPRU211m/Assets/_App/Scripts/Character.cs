using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	[SerializeField] private Rigidbody2D _theRb;

	[SerializeField] private Animator _anim;

	[SerializeField] private Transform _checkGround;

	[SerializeField] private LayerMask _maskGround;

	[SerializeField] private float _jumpForce;

	private bool _isGround;

	public void Jump()
	{
		_theRb.velocity = new Vector3(0, _jumpForce);
	}

	private void Update()
	{
		_isGround = Physics2D.OverlapCircle(_checkGround.transform.position, 0.1f, _maskGround);
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Jump();
		}
		_anim.SetBool("isGround", _isGround);
		_anim.SetBool("isFall", _theRb.velocity.y < -0.1f);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireSphere(_checkGround.transform.position, 0.1f);
	}
}
