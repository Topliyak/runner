using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
	[SerializeField] private Rigidbody _rigidbody;
	
	private void OnCollisionEnter(Collision collision) => ReactOnCollisionWithCharacter();

	virtual public void ReactOnCollisionWithCharacter()
	{
		Destroy(gameObject);
	}
}
