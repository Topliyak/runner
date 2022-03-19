using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityEventFloat : UnityEvent<float> { }

public class SpeedBooster : MonoBehaviour
{
	private bool _boosting;

	[SerializeField] private SpeedInfo _speedInfo;
	[SerializeField] private float _startSpeed;

	public UnityEventFloat speedBoostedEvent;

	public void StartBoosting()
	{
		_boosting = true;
		Boost(_startSpeed);
	}

	public void StopBoosting()
	{
		_boosting = false;
	}

	private void Boost()
	{
		if (!_boosting)
		{
			Debug.Log("Cant boost");
			return;
		}

		// Boost(any speed);
	}

	private void Boost(float speed)
	{
		if (!_boosting)
		{
			Debug.Log("Cant boost");
			return;
		}

		_speedInfo.Speed = speed;

		speedBoostedEvent.Invoke(speed);
	}
}
