using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

class ObstaclesOverEdgeChecker: MonoBehaviour
{
	private List<GameObject> _obstacles;

	[SerializeField] private Transform _edgePoint;

	[SerializeField] private UnityEvent<GameObject> _obstacleOverEdgeEvent;

	public UnityEvent<GameObject> ObstacleOverEdgeEvent => _obstacleOverEdgeEvent;

	private void Awake()
	{
		_obstacles = new List<GameObject>();
	}

	private void Update()
	{
		foreach (var obstacle in _obstacles)
		{
			if (obstacle.transform.position.z < _edgePoint.position.z)
			{
				_obstacleOverEdgeEvent.Invoke(obstacle);
				_obstacles.Remove(obstacle);
			}
		}
	}
}
