using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectorControl : MonoBehaviour
{
    public float MovementSpeed = 1;
	public float JumpForce = 1;
	public Animator animator;
	private bool Walking = false;
	private bool Idleing = false;
	private bool Running = false;
	private bool RunStop = false;
	
	private Rigidbody _rigidbody;
	
	void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
		transform.position += new Vector3(movement,0,0) * Time.deltaTime * MovementSpeed;
		
		
		if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
		{
			_rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode.Impulse);
		}
		
		//running input
		
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			if (RunStop == false)
			{
				MovementSpeed = MovementSpeed * 2;
				Running = true;
				RunStop = true;
			}
		}
		
		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			RunStop = false;
			Running = false;
			MovementSpeed = MovementSpeed / 2;
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
    }
}
