using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager_1 : MonoBehaviour
{
	   public string targetSceneName1 = "Level 1";
	   public string targetSceneName2 = "Level 2";
	   public GameObject Music1;
	   
	private void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
		SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
	
	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
	   if (scene.name == targetSceneName1)
		   {
			Music1.SetActive(true);
		   }
   	   if (scene.name == targetSceneName2)
		   {
			Music1.SetActive(true);
		   }
	   if (scene.name != targetSceneName1)
	   {
		   if (scene.name != targetSceneName2)
		   {
			Music1.SetActive(false);
		   }
	   }
	}
}
