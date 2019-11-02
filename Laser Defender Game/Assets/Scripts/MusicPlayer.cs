using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    void ChangeMusic(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Music is working " + scene.name);
        source.Stop();
        if (scene.buildIndex == 1)
        {
            source.clip = game;
        }
        else if (scene.buildIndex == 0)
        {
            source.clip = start;
        }
        else if (scene.buildIndex == 2)
        {
            source.clip = end;
        }
        source.loop = true;
        source.Play();
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += ChangeMusic;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= ChangeMusic;
    }
}
