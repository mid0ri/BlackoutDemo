using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	public static SoundManager instance = null; 
	public AudioSource sourceBackground;
	public AudioSource sourceEffect;

	public AudioClip[] audioClips;

	void Start () {
	}

	void Awake ()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)			
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
	}

	public void playSoundEffect(int index){
		sourceEffect.clip = audioClips[index];
		sourceEffect.Play ();
	}

	/*void Update(){
		if (Input.GetKey (KeyCode.Q))
			playSoundEffect (0);
	}*/
		

}
