using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
	public Animator animator;
	
	
	public void OnTriggerStay(Collider other)
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
		   animator.SetBool("NextLevel", true);
		}
	}
}

