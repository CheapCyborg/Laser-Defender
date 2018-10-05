using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	static MusicPlayer instance = null;

	public AudioClip gameClip;
	public AudioClip endClip;
	public AudioClip menuClip;

	private AudioSource music;

	void Awake()
	{
		Debug.Log("Music player awake " + GetInstanceID());
		if (instance != null && instance !=this )
		{
			Destroy(gameObject);
			print("Duplicate music player deleted");
		}
		else
		{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			music = GetComponent<AudioSource>();
			music.clip = menuClip;
			music.loop = true;
			music.Play();
		}
	}

	private void OnLevelWasLoaded(int level)
	{
		Debug.Log("Music Player loaded level " + level);
		music.Stop();

		if (level == 0)
		{
			music.clip = menuClip;
		}
		if (level == 1)
		{
			music.clip = gameClip;
		}
		if (level == 2)
		{
			music.clip = endClip;
		}
		music.loop = true;
		music.Play();
	}

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
