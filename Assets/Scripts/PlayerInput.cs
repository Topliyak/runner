using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
	[SerializeField] private KeyCode _jumpKey;

	public UnityEvent jumpComandEvent;

	void Update()
	{
		if (Input.GetKeyDown(_jumpKey))
		{
			jumpComandEvent.Invoke();
		}
	}
}
