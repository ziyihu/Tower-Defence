using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	
	public static AudioManager _instance;
	
	public AudioClip backgroundMusic;
	public AudioClip enemyKilledMusic;
	public AudioClip tower1FireMusic;
	public AudioClip tower2FireMusic;
	public AudioClip tower7FireMusic;
	public AudioClip tower10FireMusic;
	public AudioClip escapeMusic;
	public AudioClip enemyHitMusic;
	public AudioSource audioSource;
	//public AudioSource audioSource2;
	
	// Use this for initialization
	void Start () {
		_instance = this;
		audioSource.Play ();
	}

}

