using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour {
	
	public FadeEffect fade;

	public void StartGame(){
		fade.FadeControl();
	}

	public void QuitGame(){
		Application.Quit();
	}
}
