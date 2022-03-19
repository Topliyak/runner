using System.Collections.Generic;
using UnityEngine;

class ObstaclesMover: MonoBehaviour
{
	private List<GameObject> _obstacles;

	[SerializeField] private Vector3 _movingDirection;
	[SerializeField] private SpeedInfo _speedInfo;

	public bool CanMove { get; set; }

	private void Awake()
	{
		_obstacles = new List<GameObject>();
		_movingDirection.Normalize();
		CanMove = false;
	}

	private void Update()
	{
		if (CanMove)
		{
			foreach (var obstacle in _obstacles)
			{
				obstacle.transform.position += _movingDirection * _speedInfo.Speed * Time.deltaTime;
			}
		}
	}

	public void AddObstacle(GameObject obstacle)
	{
		_obstacles.Add(obstacle);
	}
}
