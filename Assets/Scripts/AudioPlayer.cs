using UnityEngine;

public enum SoundedAction: byte
{
	Jump, Crash, 
}

public class AudioPlayer : MonoBehaviour
{
	[SerializeField] private AudioSource _audioSource;
	[SerializeField] private MyDictionary<SoundedAction, AudioClip> _actionClipPairs;

	public void Play(SoundedAction soundedAction)
	{
		_audioSource.PlayOneShot(_actionClipPairs[soundedAction]);
	}

	public void PlayJump() => Play(SoundedAction.Jump);

	public void PlayCrash() => Play(SoundedAction.Crash);
}
