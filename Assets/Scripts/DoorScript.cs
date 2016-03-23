using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoorScript : MonoBehaviour {

	public HealthBarManager healthBarManager;
	private int currentNumberOfHearts;

	public void EnterDoor(){
		currentNumberOfHearts = healthBarManager.getNumberOfActiveHearts();
		SceneManager.LoadScene ("NextScene");
		Debug.Log ("health on Door " + currentNumberOfHearts);
		PlayerPrefs.SetInt("Player Health", currentNumberOfHearts);
	}
}
