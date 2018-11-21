using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	public static MusicPlayer hi;
	public AudioClip start;
	public AudioClip game;
	public AudioClip end;
	AudioSource source;
	void Awake () {
		if (hi == null) {
			DontDestroyOnLoad (gameObject);
			hi = this;
		} else if (hi != null && hi != this) {
			Destroy (gameObject);
		}
		source = GetComponent<AudioSource> ();
		source.clip = start;
		source.Play();
	}
	void OnLevelWasLoaded(int level){
		Debug.Log("Music is working "+level);
		source.Stop ();
		if (level == 1) {
			source.clip = game;
		} else if (level == 0) {
			source.clip = start;
		} else if (level == 2) {
			source.clip = end;
		}
		source.loop = true;
		source.Play ();
	}
}
