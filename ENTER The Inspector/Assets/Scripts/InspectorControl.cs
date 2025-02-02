using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectorControl : MonoBehaviour
{
    public float MovementSpeed = 1;
	public float JumpForce = 1;
	
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
    }
}
