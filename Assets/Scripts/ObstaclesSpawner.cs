using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class ObstaclesSpawner : MonoBehaviour
{
	private float _lastSpawnTime;
	private float _delayBeforeNextSpawn_sec;
	private List<GameObject> _spawnCandidates;

	[SerializeField] private Transform _spawnPoint;
	[SerializeField] private Transform _obstaclesParent;
	[SerializeField] private float _minDelayBetweenSpawns_sec;
	[SerializeField] private float _maxDelayBetweenSpawns_sec;
	[SerializeField] private GameObject[] _obstaclePrefabs;

	[SerializeField] private UnityEvent<GameObject> _obstacleSpawnedEvent;

	public UnityEvent<GameObject> ObstacleSpawnedEvent => _obstacleSpawnedEvent;

	public bool CanSpawn { get; set; }

	private void Awake()
	{
		_spawnCandidates = new List<GameObject>();
		CanSpawn = false;
		_lastSpawnTime = 0;
	}

	private void Update()
	{
		if (CanSpawn && Time.realtimeSinceStartup - _lastSpawnTime >= _delayBeforeNextSpawn_sec)
		{
			Spawn();
			_lastSpawnTime = Time.realtimeSinceStartup;
			_delayBeforeNextSpawn_sec = Random.Range(_minDelayBetweenSpawns_sec, _maxDelayBetweenSpawns_sec);
		}
	}

	private void Spawn()
	{
		GameObject obstacle = null;

		if (_spawnCandidates.Count > 0)
		{
			obstacle = _spawnCandidates[Random.Range(0, _spawnCandidates.Count)];
			obstacle.transform.position = _spawnPoint.position;
			obstacle.transform.rotation = _spawnPoint.rotation;
			obstacle.SetActive(true);
		}
		else
		{
			obstacle = Instantiate(GetRandomTemplate(), _spawnPoint.position, _spawnPoint.rotation, _obstaclesParent);
		}

		_obstacleSpawnedEvent.Invoke(obstacle);
	}

	private GameObject GetRandomTemplate() => _obstaclePrefabs[Random.Range(0, _obstaclePrefabs.Length)];

	public void AddCandidateToSpawn(GameObject obstacle)
	{
		_spawnCandidates.Add(obstacle);
		obstacle.SetActive(false);
	}
}
