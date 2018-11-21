using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
	public void ChangeScene (string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}
	public void Quit (){
		Application.Quit ();
	}
	public void LoadNextLevel(){
		SceneManager.LoadScene (Application.loadedLevel + 1);
	}
}

