using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshPause : MonoBehaviour
{
    
	public MeshRenderer PauseMesh;
	public bool GameIsPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (GameIsPaused)
			{
				GameIsPaused = false;
				PauseMesh.enabled = true;
			}
			else
			{
				GameIsPaused = true;
				PauseMesh.enabled = false;
			}
		}
    }
}
