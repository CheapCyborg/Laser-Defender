using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
	public void LoadLevel(string name)
	{
		Debug.Log("Level load requested for " + name);
		SceneManager.LoadScene(name);
	}

	public void MainMenu(string start)
	{
		Debug.Log("Return to main menu requested");
		SceneManager.LoadScene(start);
	}

	public void QuitGame()
	{
		Debug.Log("Game quit requested");
		Application.Quit();
	}

	public void LoadNextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

	}
}

