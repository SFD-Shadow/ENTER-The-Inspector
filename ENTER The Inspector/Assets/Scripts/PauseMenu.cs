using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public bool GameIsPaused = false;
	public GameObject PauseMenuUI;
	public static PauseMenu instance;
	public GameObject SettingsMenuUI;
	public GameObject PauseResume;
	
	void Awake()
	{
		if(instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
		}
	}
	
	
	void Start()
	{
		DontDestroyOnLoad(gameObject);
		PauseMenuUI.SetActive(false);
		SettingsMenuUI.SetActive(false);
		
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
		SettingsMenuUI.SetActive(false);
		PauseResume.SetActive(true);
	}
	
	void Pause ()
	{
		PauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}
	
	private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
	
	private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
	
	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameIsPaused = false;
    }
}
