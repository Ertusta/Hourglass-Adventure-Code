using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterMovement : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public float walkSpeed;
    public float walkBackSpeed;
    public float sprintSpeedMultiplier;
    public float rotateSpeed;
    public float jumpForce;
    public Transform playerTrans;

    private bool walking;
    private bool isSprinting;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("walk");
            playerAnim.ResetTrigger("idle");
            playerRigid.velocity = transform.forward * walkSpeed * Time.deltaTime;
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.ResetTrigger("walk");
            playerAnim.SetTrigger("idle");
            walking = false;
            playerRigid.velocity = Vector3.zero;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("walk");
            playerAnim.ResetTrigger("idle");
            playerRigid.velocity = -transform.forward * walkBackSpeed * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.ResetTrigger("walk");
            playerAnim.SetTrigger("idle");
            playerRigid.velocity = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerTrans.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }

        if (walking)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isSprinting = true;
                walkSpeed *= sprintSpeedMultiplier;
                playerAnim.SetTrigger("run");
                playerAnim.ResetTrigger("walk");
            }
            if (Input.GetKeyUp(KeyCode.LeftShift) || (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)))
            {
                isSprinting = false;
                walkSpeed /= sprintSpeedMultiplier;
                playerAnim.ResetTrigger("run");
                playerAnim.SetTrigger("walk");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("jump");
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            if (isSprinting)
            {
                isSprinting = false;
                walkSpeed /= sprintSpeedMultiplier;
                playerAnim.ResetTrigger("run");
                playerAnim.SetTrigger("walk");
            }
        }
    }
}
