using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public bool GameIsPaused = false;
	
	public GameObject PauseMenuUI;
	public AudioSource audioSourceFreeze1;
	public GameObject ScreenFX;
	
	void Start()
	{
		PauseMenuUI.SetActive(false);
	}

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (GameIsPaused)
			{
				Resume();
			} else
			{
				Pause();
			}
			
			
		}  
    }
	
	public void Resume ()
	{
		PauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
		audioSourceFreeze1.pitch = 1;
		ScreenFX.SetActive(true);
	}
	
	void Pause ()
	{
		PauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
		audioSourceFreeze1.pitch = 0;
		ScreenFX.SetActive(false);
	}
	
}
