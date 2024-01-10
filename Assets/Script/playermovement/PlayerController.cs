using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using JetBrains.Annotations;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
 
    // Start is called before the first frame update
    public WarriorlegendplayerControl inputControl;

    private Rigidbody2D rb;
    private CapsuleCollider2D coll;
    private Animator anim;
    public float speed, jumpForce;
    public Transform groundCheck;
    public LayerMask ground;
    public bool isGround, isJump;
    bool jumpPressed;
    int jumpCount;
    public Vector2 inputDirection;
    public float Speed;
    private void Awake() {
        inputControl = new WarriorlegendplayerControl();    

        inputControl.GamePlay.Jump.started += Jump;

        rb= GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Jump(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
      /*  if(isGround) {
            jumpCount = 2;
            isJump = false;
            
        }
        if(jumpPressed&& isGround)
        {
            isJump= true;
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
            jumpCount--;
            jumpPressed = false;
        }
        else if (jumpPressed&& jumpCount>0&& isJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
         //   anim.StopPlayback();
         //   anim.Play("jump");
            jumpCount--;
            jumpPressed=false;
        }*/
    }

    private void OnEnable() {
        inputControl.Enable();
    }
    private void OnDisable() {
        inputControl.Disable();
    }
    private void Update() {
        inputDirection = inputControl.GamePlay.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate() {
        Move();
    }
    public void Move(){
        rb.velocity = new Vector2(inputDirection.x*Speed*Time.deltaTime, rb.velocity.y);
    }
    
}
