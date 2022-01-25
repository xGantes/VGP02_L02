using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runspeed = 40f;
    float horizontalMove = 0f;

    bool jump = false;
    bool roll = false;
    bool fire = false;
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runspeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        //no chapchap spider web transition
        //animator.Play()

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            //animation jump
            animator.SetBool("isJumping", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            roll = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            roll = false;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            fire = true;
            animator.SetBool("isFiring", true);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            fire = false;
            animator.SetBool("isFiring", false);

        }
    }
    public void onLanding()
    {
        animator.SetBool("isJumping", false);
    }
    public void onCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }
    /*
    public void onFiring(bool isFiring)
    {
        animator.SetBool("isFiring", isFiring);
    } */

    void FixedUpdate()
    {
        //player movement
        controller.Move(horizontalMove * Time.fixedDeltaTime, roll, jump);
        jump = false;
    }
}
