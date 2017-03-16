using UnityEngine;
using System.Collections;
/*
 * Author : Arun Bharath Krishnan
 * Student ID : 300902831
 * */

public class AudioManager : MonoBehaviour {
	private static AudioManager instance = null;
	public static AudioManager Instance {
		get { return instance; }
	}

	[SerializeField]
	private AudioSource sfxSource;

	[SerializeField]
	private AudioSource musicSource;

	
	void Awake() {
		# region - Singleton
		if( instance == null ) {
			instance = this;
		} else if( instance != this ) {
			Destroy( gameObject );
		}
		DontDestroyOnLoad( gameObject );
		# endregion
	}


	//===================================================
	// PUBLIC METHODS
	//===================================================


	// Plays the SFX.
	
	public void PlaySFX( AudioClip clip, float volume = 1.0f ) {
		if( !sfxSource.isPlaying ) {
			sfxSource.clip = clip;
			sfxSource.volume = volume;
			sfxSource.Play();
		} else {
			PlayDynamicSound( clip, volume );
		}
	}

	// Plays the music.
	
	public void PlayMusic( AudioClip clip, float volume = 1.0f ) {
		if( musicSource.isPlaying && musicSource.clip == clip ) {
			return;
		}

		musicSource.clip = clip;
		musicSource.loop = true;
		musicSource.volume = volume;
		musicSource.Play();
	}

	// Plays the dynamic sound.
	
	private void PlayDynamicSound( AudioClip clip, float volume = 1.0f ) {
		//Create an empty game object
		GameObject sfxGO = new GameObject( "Dynamic_" + clip.name );
		sfxGO.transform.SetParent( transform );

		//Create the source
		AudioSource source = sfxGO.AddComponent<AudioSource>();
		source.clip = clip;
		source.volume = volume;
		source.Play();

		Destroy( sfxGO, clip.length );
	}

	

}
