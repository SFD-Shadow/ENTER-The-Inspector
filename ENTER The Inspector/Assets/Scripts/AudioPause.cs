using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPause : MonoBehaviour
{
    
	public AudioSource pauseAudio;
	public bool GameIsPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (GameIsPaused)
			{
				GameIsPaused = false;
				pauseAudio.pitch = 1;
			}
			else
			{
				GameIsPaused = true;
				pauseAudio.pitch = 0;
			}
		}
    }
}
