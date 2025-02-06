using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InputFieldHandler : MonoBehaviour
{
    public TMP_InputField inputField; 
	public int targetFPS = 24;
	public bool FPS_limiter = true;
	public bool VSYNC = true;
	
	public void UpdateNumber()
    {
        if (int.TryParse(inputField.text, out int newValue))
        {
            targetFPS = newValue;
            Debug.Log("Updated myNumber: " + targetFPS);
        }
        else
        {
            Debug.LogWarning("Invalid input: Not a number");
        }
    }
	
	public void Update()
	{
		if (FPS_limiter == true)
		{
		   Application.targetFrameRate = targetFPS;
		}
		else
		{
			Application.targetFrameRate = 9999;
		}
		
		
		
		if (VSYNC == true)
		{
			QualitySettings.vSyncCount = 1;
		}
		else
		{
			QualitySettings.vSyncCount = 0;
		}  

	}
	
	// all the stupid stuff for the button to work :/
	
	public void ToggleVSYNC()
	{
		VSYNC = !VSYNC;
	}
	
	public void ToggleFPSlimiter()
	{
		FPS_limiter = !FPS_limiter;
	}
	
}