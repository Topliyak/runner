using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
	private int _jumpedInARaw;
	private bool _dead;

	[SerializeField] private Rigidbody _rigidbody;
	[SerializeField] private float _jumpForce;
	[SerializeField] private int _maxJumpCount;
	[SerializeField] private LayerMask _groundLayerMask;
	[SerializeField] private LayerMask _obstaclesLayerMask;

	public UnityEvent jumpedEvent;
	public UnityEvent landedEvent;
	public UnityEvent obstacleCollidedEvent;

	private void OnEnable()
	{
		landedEvent.AddListener(OnLanded);
		obstacleCollidedEvent.AddListener(Die);
	}

	private void OnDisable()
	{
		landedEvent.RemoveListener(OnLanded);
		obstacleCollidedEvent.RemoveListener(Die);
	}

	private void Awake()
	{
		_dead = false;
	}

	public void TryJump()
	{
		if (_dead)
		{
			Debug.Log("Dead");
			return;
		}

		if (_jumpedInARaw >= _maxJumpCount)
		{
			Debug.Log("Cant jump");
			return;
		}

		_rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
		_jumpedInARaw++;

		jumpedEvent.Invoke();
		Debug.Log("Jumped");
	}

	public void Die()
	{
		_dead = true;
	}

	private void OnLanded()
	{
		_jumpedInARaw = 0;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (_dead)
		{
			return;
		}
		if (MyLayers.IsLayerInMask(collision.gameObject.layer, _groundLayerMask))
		{
			landedEvent.Invoke();
			Debug.Log("Landed");
		}
		else if (MyLayers.IsLayerInMask(collision.gameObject.layer, _obstaclesLayerMask))
		{
			obstacleCollidedEvent.Invoke();
			Debug.Log("Collided to obstacle");
		}
	}
}
