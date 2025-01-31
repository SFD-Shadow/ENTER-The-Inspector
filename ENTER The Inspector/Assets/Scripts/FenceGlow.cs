using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FenceGlow : MonoBehaviour
{
	
	public Animator animator;

	
	public void OnTriggerEnter(Collider other)
	{
		animator.SetBool("FenceGlow", true);
	}
	
	public void OnTriggerExit(Collider other)
	{
		animator.SetBool("FenceGlow", false);
	}
}

