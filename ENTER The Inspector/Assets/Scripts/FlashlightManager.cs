using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightManager : MonoBehaviour
{
	public bool Flashlight = false;
	public Animator animator;
	public GameObject FlashLight;
	
	void Start()
	{
		FlashLight.SetActive(false);
	}

    void Update()
    {
		var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		
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
		FlashLight.SetActive(false);
		Flashlight = false;
		animator.SetBool("LookAtLight", false);
	}
	
	void Off ()
	{
		FlashLight.SetActive(true);
		Flashlight = true;
		animator.SetBool("LookAtLight", true);
	}
	
}
