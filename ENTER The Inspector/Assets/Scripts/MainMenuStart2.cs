using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuStart2 : StateMachineBehaviour
{
	public void OnStateEnter()
	{
		SceneManager.LoadSceneAsync("Level 1");
	}
}
