using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dream_DoggoMovement : MonoBehaviour
{
    public Dream_Character2DController controller;
    public Animator animator;
    public Rigidbody2D body;
    public float runSpeed = 10f;

    float horizontalMove = 0f;
    float jumpForce = 20f;
    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("space")) //Jump
		{
			jump = true;
		}
    }

    public void OnLanding() {
        animator.SetBool("isJumping", false);   
    }

     void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	} 
}
