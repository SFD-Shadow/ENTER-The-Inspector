using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectorControl : MonoBehaviour
{
    public float MovementSpeed = 1;
	public float JumpForce = 1;
	public Animator animator;
	public LayerMask GROUND;
	private bool Walking = false;
	private bool Idleing = false;
	private bool Running = false;
	private bool RunStop = false;
	public bool IsGrounded = false;
	private bool StopWalk = false;
	
	private Rigidbody _rigidbody;
	
	void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
		IsGrounded = true;
    }

    //Is grounded check

    private void OnCollisionEnter(Collision collision)
	{
		IsGrounded = true;
		animator.SetBool("Jump", false);
		animator.SetBool("IsGrounded", true);
	}
	
	private void OnCollisionExit(Collision collision)
	{
		IsGrounded = false;
		animator.SetBool("Jump", true);
		animator.SetBool("IsGrounded", false);
	}
	
	//Movement & Jumping
	
	void Update()
    {
        if (StopWalk == false)
		{
		    var movement = Input.GetAxis("Horizontal");
		    transform.position += new Vector3(movement,0,0) * Time.deltaTime * MovementSpeed;
		
		    if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
		    {
		        _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode.Impulse);
		    }
		}
		
		//running input
		
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			if (RunStop == false)
			{
				MovementSpeed = 5;
				Running = true;
				RunStop = true;
			}
		}
		
		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			RunStop = false;
			Running = false;
			MovementSpeed = 3;
		}
		
		
		//check if the player is walking, not running
		
		
		if (Input.GetKey(KeyCode.D)) 
	    {
            Walking = true;
	    	Idleing = false;
	        animator.SetBool("Flip", false);
        }
	    else if (Input.GetKey(KeyCode.A)) 
	    {
	    	Walking = true;
			Idleing = false;
	        animator.SetBool("Flip", true);	
    	}
	    else
	    {
	    	Idleing = true;
	    	Walking = false;
	    }
		
	
		//trigger walking paramater
		
		if (Walking)
		{
			animator.SetBool("Walk", true);
		}
		else
		{
			animator.SetBool("Walk", false);
		}
		
		//trigger idle paramater
		
		if (Idleing)
		{
			animator.SetBool("Idle", true);
		}
		else
		{
			animator.SetBool("Idle", false);
		}
		
		//trigger running paramater
		
		if (Running)
		{
			animator.SetBool("Run", true);
		}
		else
		{
			animator.SetBool("Run", false);
		}
		
		//Looking torwards or away from 4th wall
		
		if (Input.GetKey(KeyCode.W))
		{
			animator.SetBool("LookForward", true);
			StopWalk = true;
		}
		else if (Input.GetKey(KeyCode.S))
		{
			animator.SetBool("LookBack", true);
			StopWalk = true;
		}
		else
		{
			animator.SetBool("LookForward", false);
			animator.SetBool("LookBack", false);
			StopWalk = false;
		}
    }
}
