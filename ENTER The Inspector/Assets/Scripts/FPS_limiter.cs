using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_limiter : MonoBehaviour
{
    
	public int targetFPS = 24;
	
	// Start is called before the first frame update
    void Start()
    {
       QualitySettings.vSyncCount = 0;
	   Application.targetFrameRate = targetFPS;
    }

}
