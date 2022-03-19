using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Startup : MonoBehaviour
{
	public UnityEvent ranEvent;

	private void Start()
	{
		ranEvent.Invoke();
	}
}
