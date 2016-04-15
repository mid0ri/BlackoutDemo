using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoorScript : MonoBehaviour {

	public HealthBarManager healthBarManager;
	private int currentNumberOfHearts;

	public void EnterDoor(){
		currentNumberOfHearts = healthBarManager.getNumberOfActiveHearts();
		GameManager.instance.health = currentNumberOfHearts;
		SceneManager.LoadScene ("Level02");

	}
}
