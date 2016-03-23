using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string startLevel;
	public string instructions;
	public string continueGame;
	public string back;



	public void NewGame()
	{
		
		SceneManager.LoadScene (startLevel);
	}

	public void Continue()
	{
		SceneManager.LoadScene (continueGame);
	}

	public void Instructions()
	{
		SceneManager.LoadScene (instructions);
	}

	public void BackToMain()
	{
		SceneManager.LoadScene (back);
	}

	public void QuitGame()
	{
		Application.Quit ();
	}
}
