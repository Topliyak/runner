using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFlagsSwitcher : MonoBehaviour
{
	private const string _runParameter = "Static_b";
	private const string _speedParameter = "Speed_f";
	private const string _groundedParameter = "Grounded";
	private const string _deadParameter = "Death_b";

	[SerializeField] private Animator _animator;

	public Animator Animator
	{
		get => _animator;
		set => _animator = value;
	}

	public void SwitchToRun()
	{
		_animator.SetBool(_deadParameter, false);
		_animator.SetBool(_groundedParameter, true);
		_animator.SetBool(_runParameter, true);
		_animator.SetFloat(_speedParameter, 1);
	}

	public void SwitchToIdle()
	{
		_animator.SetBool(_deadParameter, false);
		_animator.SetBool(_groundedParameter, true);
		_animator.SetBool(_runParameter, false);
		_animator.SetFloat(_speedParameter, 0);
	}

	public void SwitchToInAir()
	{
		_animator.SetBool(_deadParameter, false);
		_animator.SetBool(_groundedParameter, false);
	}

	public void SwitchToPassedOut()
	{
		_animator.SetBool(_deadParameter, true);
	}
}
