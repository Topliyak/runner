using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
	private int _leftBackgroundIndex;

	[SerializeField] private float _backgroundWidth;
	[SerializeField] private SpriteRenderer _backgroundSpriteInfo;
	[SerializeField] private Vector3 _direction;
	[SerializeField] private Transform _leftEdge;
	[SerializeField] private Transform[] _backgrounds;

	private int RightBackgroundIndex => (_leftBackgroundIndex + _backgrounds.Length - 1) % _backgrounds.Length;

	private Transform LeftBackground => _backgrounds[_leftBackgroundIndex];

	private Transform RightBackground => _backgrounds[RightBackgroundIndex];

	public float Speed { get; set; }

	public bool Moving { get; set; }

	private void Start()
	{
		_direction.Normalize();

		_leftBackgroundIndex = 0;
		_backgrounds[0].position = _leftEdge.position;

		for (int i = 1; i < _backgrounds.Length; i++)
		{
			_backgrounds[i].position = _backgrounds[i - 1].position - _direction * _backgroundWidth;
		}
	}

	private void Update()
	{
		if (Moving)
		{
			foreach (Transform background in _backgrounds)
			{
				background.position += _direction * Speed * Time.deltaTime;
			}
		}

		if (LeftBackground.position.z < _leftEdge.position.z)
		{
			LeftBackground.position = RightBackground.position - _direction * _backgroundWidth;

			_leftBackgroundIndex++;
			_leftBackgroundIndex %= _backgrounds.Length;
		}
	}
}
