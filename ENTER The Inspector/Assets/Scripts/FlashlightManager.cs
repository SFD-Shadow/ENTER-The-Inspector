using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightManager : MonoBehaviour
{
	public bool Flashlight = false;
	
	public GameObject OffMenuUI;
	
	void Start()
	{
		OffMenuUI.SetActive(false);
	}

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.F))
		{
			if (Flashlight)
			{
				On();
			} else
			{
				Off();
			}
			
			
		}  
    }
	
	public void On ()
	{
		OffMenuUI.SetActive(false);
		Flashlight = false;
	}
	
	void Off ()
	{
		OffMenuUI.SetActive(true);
		Flashlight = true;
	}
	
}
