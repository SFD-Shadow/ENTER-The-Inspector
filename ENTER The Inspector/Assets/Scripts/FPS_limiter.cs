using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_limiter : MonoBehaviour
{  
	public int targetFPS = 24;
	
    public void Update()
    {
       QualitySettings.vSyncCount = 0;
	   Application.targetFrameRate = targetFPS;
    }

}
